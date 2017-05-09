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
    }

    public void Examine()
    {
        if (CurrentState != null)
            _currentState.OnExamine.Invoke();
    }

    public void Combine()
    {
        if (CurrentState != null)
            _currentState.OnCombine.Invoke();
        
        //InventoryManager.Combine(this);
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
    
    /// <summary>
    /// Change the state of the object
    /// </summary>
    /// <param name="state">New state</param>
    public void SetState(InteractiveObjectState state)
    {
        CurrentState = state;
    }

    /// <summary>
    /// Destroy this object
    /// </summary>
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
