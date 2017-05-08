using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    public LayerMask ObjectsLayer;
    public string InteractiveTag;

    [Header("Settings")]
    public float RaycastRange;
    public float InteractionRange;

    [Header("Commands")]
    public string UseCmd;
    public string ExamineCmd;
    public string CombineCmd;

    InteractiveObject _currentSelection;
    bool HasSelection { get { return _currentSelection != null; } }

    void Update()
    {
        PlayerCanvas.ClearHint();
        if (!GameManager.FirstPersonMode)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, RaycastRange, ObjectsLayer, QueryTriggerInteraction.Collide))
        {
            if (!hit.collider.CompareTag(InteractiveTag))
                return;

            _currentSelection = hit.collider.GetComponent<InteractiveObject>();
            if (_currentSelection != null)
            {
                PlayerCanvas.ShowHint(_currentSelection.Title.ToUpper());
            }

            if(HasSelection)
            {
                if (Input.GetButtonDown(UseCmd))
                {
                    if (hit.distance > InteractionRange)
                    {
                        DialogueManager.PlayDialogue("toofar");
                        return;
                    }
                    _currentSelection.Use();
                    _currentSelection = null;
                }
                else if (Input.GetButtonDown(ExamineCmd))
                {
                    if (hit.distance > InteractionRange)
                    {
                        DialogueManager.PlayDialogue("toofar");
                        return;
                    }
                    _currentSelection.Examine();
                    _currentSelection = null;
                }
                else if (Input.GetButtonDown(CombineCmd))
                {
                    if (hit.distance > InteractionRange)
                    {
                        DialogueManager.PlayDialogue("toofar");
                        return;
                    }

                    _currentSelection.Combine();
                    _currentSelection = null;
                }

            }
        }
        else
        {
            _currentSelection = null;
        }
    }
}
