using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "Dialogue", menuName = "Adventure/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string Key;
    public List<DialogueLine> Lines;
}

[System.Serializable]
public class DialogueLine
{
    public Character Speaker; 
    [Multiline] public string Line;
}

//who is talking
public enum Character
{
    Player,
    NPC
}
