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

    [Header("Death")]
    public Transform RespawnPoint;

    [Header("Moods")]
    public Color HouseMood;
    public Color SubconsciousMood;
    public float colorTransition;
    Coroutine transitionRoutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FirstPersonMode = !FirstPersonMode;
    }

    #region First Person Mode
    public void EnterFirstPerson()
    {
        FirstPersonMode = true;
    }

    public void QuitFirstPerson()
    {
        FirstPersonMode = false;
    }

    #endregion

    #region Ambient Color
    public void SetHouseMood()
    {
        if (transitionRoutine != null)
            StopCoroutine(transitionRoutine);
        transitionRoutine = StartCoroutine(MoodTransition(HouseMood));
    }

    public void SetSubconsciousMood()
    {
        if(transitionRoutine != null)
            StopCoroutine(transitionRoutine);
        transitionRoutine = StartCoroutine(MoodTransition(SubconsciousMood));
    }

    IEnumerator MoodTransition(Color newMood)
    {
        for (int i = 0; i < 1000; i++)
        {
            var r = Mathf.Lerp(RenderSettings.ambientSkyColor.r, newMood.r, colorTransition);
            var g = Mathf.Lerp(RenderSettings.ambientSkyColor.g, newMood.g, colorTransition);
            var b = Mathf.Lerp(RenderSettings.ambientSkyColor.b, newMood.b, colorTransition);
            RenderSettings.ambientSkyColor = new Color(r, g, b);
            yield return null;
        }
    }
    #endregion

    #region Death
    public void Respawn()
    {
        var player = FindObjectOfType<FirstPerson>();
        player.transform.position = RespawnPoint.position;
    }
#endregion
}

public enum Mood
{
    House,
    Subsconscious
}
