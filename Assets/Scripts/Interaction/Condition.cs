using UnityEngine;

[System.Serializable]
public class Condition : ScriptableObject
{
    public string Name;
    public string Key;
    public bool IsSatisfied;
}
