﻿using UnityEngine;

[System.Serializable]
public class CombinationCondition
{
    public string Name;
    public bool IsSatisfied;
    public Item RequiredItem;
    public Dialogue OptionalDialogue;
}
