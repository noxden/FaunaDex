//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 07-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandOverHandler : MonoBehaviour
{
    [Header("GameObject Links")]
    [SerializeField]
    private DialogueEntry requiredDialogueEntry;

    [SerializeField]
    private Button handOverButton;

    //# Private Variables 
    private PlayerController player;
    private DialogueDisplayHelper dialogueDisplay;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        dialogueDisplay = FindObjectOfType<DialogueDisplayHelper>();

        dialogueDisplay.OnTextStartedDisplaying.AddListener(CheckForRequirement);
        handOverButton.onClick.AddListener(OnHandOverButtonPressed);

        handOverButton.gameObject.SetActive(false);
    }

    public void CheckForRequirement(List<Expression> _)
    {
        if (dialogueDisplay.selectedEntry == requiredDialogueEntry)
        {
            // Debug.Log($"HandOverManager: Requirement has been matched.", this);
            EnableHandOver();
        }
    }

    private void EnableHandOver()
    {
        player.canTalk = false;
        handOverButton.gameObject.SetActive(true);
    }

    private void OnHandOverButtonPressed()
    {
        //TODO: Play optional handover animation here
        dialogueDisplay.Display();
        DisableHandOver();
    }

    private void DisableHandOver()
    {
        handOverButton.gameObject.SetActive(false);
        player.canTalk = true;
    }
}
