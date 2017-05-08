using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : vnc.Utilities.SingletonMonoBehaviour<PlayerCanvas>
{
    #region Singleton
    private void Awake()
    {
        CreateSingleton();
    }

    public override void CreateSingleton()
    {
        Singleton = this;
    }
    #endregion

    [Header("References")]
    public Text Hint;

    #region Hint
    // When the player look at the object, a "hint"
    // appesar so it can identify theobject
    public static void ClearHint()
    {
        Singleton.Hint.text = string.Empty;
    }

    public static void ShowHint(string label)
    {
        Singleton.Hint.text = label;
    }
    #endregion
}
