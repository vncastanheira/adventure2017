using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    [Header("Options")]
    public string Title;
    public Item Item;
    public bool IsItem
    {
        get
        {
            return Item != null;
        }
    }

    [Header("Dialogues")]
    public Dialogue ExamineDialogue;
    public Dialogue UseDialogue;
    public Dialogue CannotUseDialogue;

    List<Condition> Conditions;
    public UnityEvent OnUse;

    private void Start()
    {
        Conditions = GetComponents<Condition>().ToList();
    }

    public void Use()
    {
        if (IsItem)
        {
            InventoryManager.Add(Item);
            Destroy(gameObject);
            return;
        }

        if(Conditions.Count == 0 || Conditions.All(c => c.IsSatisfied))
        {
            DialogueManager.PlayDialogue(UseDialogue);
            OnUse.Invoke();
        }
        else
        {
            DialogueManager.PlayDialogue(CannotUseDialogue);
        }
    }

    public void Examine()
    {
        DialogueManager.PlayDialogue(ExamineDialogue);
    }

    public void Combine()
    {
        InventoryManager.Combine(this);
    }

    public bool TrySatisfyCondition(Item useItem)
    {
        if(Conditions == null)
        {
            // TODO: Feedback
            Debug.LogWarning("No conditions met");
        }
        else
        {
            var condition = Conditions.Find(c => c.RequiredItem == useItem);
            if(condition != null)
            {
                condition.IsSatisfied = true;
                return true;
            }
        }
        
        return false;
    }
}
