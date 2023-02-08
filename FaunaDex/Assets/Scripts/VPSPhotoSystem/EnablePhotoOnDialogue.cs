//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 07-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePhotoOnDialogue : MonoBehaviour
{
    [Header("GameObject Links")]
    [SerializeField]
    private DialogueEntry requiredDialogueEntry;

    //# Private Variables 
    private PhotoHandler photoHandler;

    private DialogueDisplayHelper dialogueDisplay;

    private void Start()
    {
        photoHandler = FindObjectOfType<PhotoHandler>();
        dialogueDisplay = FindObjectOfType<DialogueDisplayHelper>();

        dialogueDisplay.OnTextStartedDisplaying.AddListener(CheckForRequirement);
        dialogueDisplay.OnDialogueFinished.AddListener(CheckForRequirement);
    }

    public void CheckForRequirement(List<Expression> _)
    {
        if (dialogueDisplay.selectedEntry == requiredDialogueEntry)
        {
            FindObjectOfType<LayerHelper>()?.SetLayerToRaycastTarget();
            EnablePhotoMode();
        }
    }

    public void CheckForRequirement()
    {
        if (dialogueDisplay.selectedEntry == requiredDialogueEntry)
        {
            FindObjectOfType<LayerHelper>()?.SetLayerToRaycastTarget();
            EnablePhotoMode();
        }
    }

    private void EnablePhotoMode()
    {
        photoHandler.isPhotoTakingEnabled = true;
    }

    private void DisablePhotoMode()
    {
        photoHandler.isPhotoTakingEnabled = false;
    }
}
