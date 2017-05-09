using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractiveObjectState : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnUse;
    public UnityEvent OnExamine;
    public UnityEvent OnCombine;
    public UnityEvent OnCombinationSuccess;

    [Header("Conditions")]
    public List<CombinationCondition> Conditions;

    public void CheckConditionsSatisfied()
    {
        if(Conditions != null && Conditions.All(c => c.IsSatisfied))
        {
            OnCombinationSuccess.Invoke();
        }
    }
}
