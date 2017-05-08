using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    public string Title;

    public List<Condition> Conditions;
    public UnityEvent OnInteraction;
	
    public void Interact()
    {
        OnInteraction.Invoke();
    }
}
