using UnityEngine;

[System.Serializable]
public class Condition : ScriptableObject
{
    public string Name;
    public bool IsSatisfied;
    public Item RequiredItem;
    public Dialogue OptionalDialogue;
}
