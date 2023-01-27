//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 25-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButtonsManager : MonoBehaviour
{
    //# Public Variables 
    public Button ARModeButton;


    //# Private Variables 
    private MapPlayer player;

    //# Monobehaviour Events 
    private void Awake()
    {
        if (ARModeButton != null)
            Disable_ARModeButton();
        else
            Debug.LogError($"Variable \"ARModeButton\" in MapButtonsManager has not been assigned.", this);
    }

    private void Start()
    {
        player = FindObjectOfType<MapPlayer>();
    }

    //# Public Methods 
    public void Enable_ARModeButton()
    {
        ARModeButton.interactable = true;
    }

    public void Disable_ARModeButton()
    {
        ARModeButton.interactable = false;
    }

    //# Input Event Handlers 


    public void OnARModeButtonClicked()
    {
        if (player.selectedScene.HasValue)  //< Should not be necessary, as the button should be in a deactivated state whenever selectedScene is null / has no value, but still...
            SceneTransitionManager.LoadScene((Scene)player.selectedScene);
    }

    public void OnFaundaDexButtonClicked()
    {

    }

    public void OnQuestTrackerButtonClicked()
    {

    }
}
