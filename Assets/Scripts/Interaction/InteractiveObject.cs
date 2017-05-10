using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    [Header("Options")]
    public string Title;
    public InteractiveObjectState FirstState;
    InteractiveObjectState _currentState;

    private void Start()
    {
        _currentState = FirstState;
        if (FirstState == null)
            Debug.LogWarning("No first state was set for object " + name);
    }

    public void Use()
    {
        if (_currentState != null)
            _currentState.OnUse.Invoke();
    }

    public void Examine()
    {
        if (_currentState != null)
            _currentState.OnExamine.Invoke();
    }

    public void Combine()
    {
        if (_currentState != null)
        {
            _currentState.OnCombine.Invoke();
        }
    }

    public bool TrySatisfyCondition(Item useItem)
    {
        if (_currentState.Conditions == null)
        {
            // TODO: Feedback
            Debug.LogWarning("No conditions met");
        }
        else
        {
            var condition = _currentState.Conditions.Find(c => c.RequiredItem == useItem);
            if (condition != null)
            {
                condition.IsSatisfied = true;
                return true;
            }
        }

        return false;
    }

    public void CheckConditionsSatisfied()
    {
        _currentState.CheckConditionsSatisfied();
    }

    /// <summary>
    /// Change the state of the object
    /// </summary>
    /// <param name="state">New state</param>
    public void SetState(InteractiveObjectState state)
    {
        _currentState = state;
    }

    /// <summary>
    /// Destroy this object
    /// </summary>
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
