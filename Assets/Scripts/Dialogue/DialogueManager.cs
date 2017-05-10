using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DialogueManager : vnc.Utilities.SingletonMonoBehaviour<DialogueManager>
{
    [Header("Canvas")]
    public Text DialogueText;

    /// <summary>All dialogues in the game</summary>
    public List<Dialogue> Dialogues;
    static Dialogue currentDialogue;
    static Coroutine dialogueRoutine;
    bool canSkip;

    #region Singleton
    private void Awake()
    {
        CreateSingleton();
    }

    public override void CreateSingleton()
    {
        Singleton = this;
    }
    #endregion

    void Update()
    {
        canSkip = Input.GetButtonDown("Skip");
    }

    /// <summary> Play a dialogue from an object</summary>
    /// <param name="dialogue">The dialogue object</param>
    public static void PlayDialogue(Dialogue dialogue)
    {
        if(dialogue == null)
        {
            Debug.LogWarning("Dialogue is null");
            return;
        }

        Singleton.RunDialogue(dialogue);
    }

    /// <summary> Play dialogue from the manager </summary>
    /// <param name="key">The key corresponding the dialogue</param>
    public static void PlayDialogue(string key)
    {
        var dialogue = Singleton.Dialogues
            .FirstOrDefault(d => d.Key.Equals(key, System.StringComparison.InvariantCultureIgnoreCase));

        Singleton.RunDialogue(dialogue);
    }

    public void RunDialogue(Dialogue dialogue)
    {
        if (dialogue != null)
        {
            if (dialogueRoutine != null)
            {
                Singleton.DialogueText.text = string.Empty;
                StopCoroutine(dialogueRoutine);
            }

            currentDialogue = dialogue;
            dialogueRoutine = Singleton.StartCoroutine(StartDialogue());
        }
        else // this can never happen
        {
            Debug.LogWarning("Dialogue not found");
        }
    }

    static IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(0.5f);
        int index = 0;
        var currentLine = currentDialogue.Lines.First();
        while (currentLine != null)
        {
            Singleton.canSkip = false;
            StringReader reader = new StringReader(currentLine.Line);
            Singleton.DialogueText.text = "";

            switch (currentLine.Speaker)
            {
                case Character.Player:
                    Singleton.DialogueText.text = "<color=#99e550>You:</color> ";
                    break;
                case Character.Narrator:
                    Singleton.DialogueText.text = "<color=#99e550>Narrator:</color> ";
                    break;
                default:
                    Singleton.DialogueText.text = "<color=#99e550>???:</color> ";
                    break;
            }

            foreach (var c in reader.ReadToEnd())
            {
                Singleton.DialogueText.text += c;
                yield return new WaitForSeconds(0.02f);
            }

            index++;
            currentLine = currentDialogue.Lines.ElementAtOrDefault(index);
            yield return new WaitUntil(() => { return Singleton.canSkip;  });
        }
        Singleton.DialogueText.text = "";
    }

}
