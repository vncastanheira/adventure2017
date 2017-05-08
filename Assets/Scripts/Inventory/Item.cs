using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "Item", menuName = "Adventure/Item")]
public class Item : ScriptableObject
{
    public string Title;
    [Tooltip("Use this to combine with objects in the room")]
    public Sprite Icon;

    [Header("Optional")]
    public Dialogue Description;
    public Dialogue IfCombined;
    public Dialogue CannotCombine;
}
