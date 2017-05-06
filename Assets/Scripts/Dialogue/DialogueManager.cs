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
    public Animator CanvasAnimator;

    [Header("Dialogues")]
    public List<Dialogue> Dialogues;
    static Dialogue currentDialogue;
    bool fastFoward;
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

    public static void PlayDialogue(string key)
    {
        var dialogue = Singleton.Dialogues
            .FirstOrDefault(d => d.Key.Equals(key, System.StringComparison.InvariantCultureIgnoreCase));
        if (dialogue != null)
        {
            currentDialogue = dialogue;
            Singleton.StartCoroutine(StartDialogue());
        }
        else
        {
            Singleton.DialogueText.text = "Key " + key + " not found"; 
        }
    }

    static IEnumerator StartDialogue()
    {
        Singleton.CanvasAnimator.SetTrigger("Dialogue_Start");
        yield return new WaitForSeconds(0.5f);
        int index = 0;
        var currentLine = currentDialogue.Lines.First();
        while (currentLine != null)
        {
            Singleton.canSkip = false;
            StringReader reader = new StringReader(currentLine.Line);
            Singleton.DialogueText.text = "";
            foreach (var c in reader.ReadToEnd())
            {
                Singleton.DialogueText.text += c;
                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitUntil(() => { return Singleton.canSkip; });

            index++;
            currentLine = currentDialogue.Lines.ElementAtOrDefault(index);
        }
        Singleton.DialogueText.text = "";
        Singleton.CanvasAnimator.SetTrigger("Dialogue_End");
    }
}
