using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    [Header("Options")]
    public string Title;

    [Header("States")]
    public List<InteractiveObjectState> States;
    [HideInInspector] public InteractiveObjectState CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            _currentState = value;
        }
    }
    InteractiveObjectState _currentState;

    private void Start()
    {
        CurrentState = States.FirstOrDefault();
    }

    public void Use()
    {
        if(CurrentState != null)
            _currentState.OnUse.Invoke();

        //if(Conditions.Count == 0 || Conditions.All(c => c.IsSatisfied))
        //{
        //    DialogueManager.PlayDialogue(UseDialogue);
        //    OnUse.Invoke();
        //}
        //else
        //{
        //    DialogueManager.PlayDialogue(CannotUseDialogue);
        //}
    }

    public void Examine()
    {
        if (CurrentState != null)
            _currentState.OnExamine.Invoke();
        //DialogueManager.PlayDialogue(ExamineDialogue);
    }

    public void Combine()
    {
        InventoryManager.Combine(this);
    }

    public bool TrySatisfyCondition(Item useItem)
    {
        if(_currentState.Conditions == null)
        {
            // TODO: Feedback
            Debug.LogWarning("No conditions met");
        }
        else
        {
            var condition = _currentState.Conditions.Find(c => c.RequiredItem == useItem);
            if(condition != null)
            {
                condition.IsSatisfied = true;
                return true;
            }
        }
        
        return false;
    }

    public void SetState(InteractiveObjectState state)
    {
        CurrentState = state;
    }
}
