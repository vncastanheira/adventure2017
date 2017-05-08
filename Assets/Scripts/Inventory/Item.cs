using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "Item", menuName = "Adventure/Item")]
public class Item : ScriptableObject
{
    public string Title;
    [Tooltip("Use this to combine with objects in the room")]
    public string Key;
    public Sprite Icon;
}
