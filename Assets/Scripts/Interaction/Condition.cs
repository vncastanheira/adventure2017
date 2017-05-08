using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "Condition", menuName = "Adventure/Condition")]
public class Condition : ScriptableObject
{
    public string Name;
    public string Key;
    public bool IsSatisfied;
}
