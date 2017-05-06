using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

#if UNITY_EDITOR
    public void DebugPlayIntro()
    {
        DialogueManager.PlayDialogue("Intro");
    }
#endif
}
