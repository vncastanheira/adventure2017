using UnityEngine;

public class InteractivePanel : MonoBehaviour
{
    [Tooltip("If Main Panel, exiting it returns to first person mode")]
    public bool isMainPanel;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public virtual void ShowPanel()
    {
        if (isMainPanel)
            GameManager.Singleton.QuitFirstPerson();
        gameObject.SetActive(true);
    }

    public void ExitPanel()
    {
        if (isMainPanel)
            GameManager.Singleton.EnterFirstPerson();
        gameObject.SetActive(false);
    }
}