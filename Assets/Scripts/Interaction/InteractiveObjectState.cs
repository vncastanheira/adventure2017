using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractiveObjectState : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnUse;
    public UnityEvent OnExamine;
    public UnityEvent OnCombine;

    [Header("Conditions")]
    public List<Condition> Conditions;
}
