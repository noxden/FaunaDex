//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 08-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapNotificationHelper : MonoBehaviour
{
    private void Start()
    {
        string welcomeText = "Hello and welcome to our game FaunaDex Blablabla blablabla";
        ScreenNotification popup = ScreenNotificationHandler.GeneratePopUp(welcomeText, "Continue", out UnityEvent OnClick);
        OnClick.AddListener(popup.Close);

        //> This is how you can decide which one to take, even if you don't need the out
        // ScreenNotificationHandler.GeneratePopUp(welcomeText, "Continue", out ScreenNotification PopUp).AddListener(PopUp.Close);
    }
}
