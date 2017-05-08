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

    [Header("Dialogue keys")]
    public Dialogue ExamineDialogue;
    public Dialogue UseDialogue;

    public List<Condition> Conditions;
    public UnityEvent OnUse;
	
    public void Use()
    {
        if (IsItem)
        {
            InventoryManager.Add(Item);
            Destroy(gameObject);
            return;
        }

        if (UseDialogue != null)
            DialogueManager.PlayDialogue(UseDialogue);

        OnUse.Invoke();
    }

    public void Examine()
    {
        DialogueManager.PlayDialogue(ExamineDialogue);
    }

    public void Combine()
    {
        InventoryManager.Combine(this);
    }

    public bool TrySatisfyCondition(string key)
    {
        if(Conditions == null)
        {
            // TODO: Feedback
            Debug.LogWarning("No conditions met");
        }
        else
        {
            var condition = Conditions.Find(c => c.Key.Equals(key));
            if(condition != null)
            {
                condition.IsSatisfied = true;
                return true;
            }
        }
        
        return false;
    }
}
