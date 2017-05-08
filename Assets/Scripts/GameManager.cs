using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : vnc.Utilities.SingletonMonoBehaviour<GameManager>
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

    [HideInInspector] public static bool FirstPersonMode = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FirstPersonMode = !FirstPersonMode;
    }
}
