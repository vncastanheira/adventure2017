using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    public LayerMask InteractiveObjects;

    [Header("Settings")]
    public float RaycastRange;
    public float InteractionRange;
    public string Command;

    InteractiveObject _currentSelection;
    bool HasSelection { get { return _currentSelection != null; } }

    void Update()
    {
        PlayerCanvas.ClearHint();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RaycastRange, InteractiveObjects, QueryTriggerInteraction.Collide))
        {
            _currentSelection = hit.collider.GetComponent<InteractiveObject>();
            if (_currentSelection != null)
            {
                PlayerCanvas.ShowHint(_currentSelection.Title.ToUpper());
            }

            if (Input.GetButtonDown(Command) && HasSelection)
            {
                if (hit.distance > InteractionRange)
                {
                    DialogueManager.PlayDialogue("toofar");
                    return;
                }
                _currentSelection.Interact();
                 _currentSelection = null;
                Debug.Log("Interaction succeeded.");
            }
        }
        else
        {
            _currentSelection = null;
        }
    }
}
