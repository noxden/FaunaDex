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
        //> Old system where I tried implementing a dynamic generation method
        // string welcomeText = "Hello and welcome to our game FaunaDex Blablabla blablabla";
        // ScreenNotification popup = ScreenNotificationHandler.GeneratePopUp(welcomeText, "Continue", out UnityEvent OnClick);
        // OnClick.AddListener(popup.Close);

        //> This is how you can decide which one to take, even if you don't need the out
        // ScreenNotificationHandler.GeneratePopUp(welcomeText, "Continue", out ScreenNotification PopUp).AddListener(PopUp.Close);

        if (!PersistentData.wasWelcomed)
            OnWelcome();
    }

    public void OnWelcome()
    {
        ScreenNotification notification = ScreenNotificationHandler.Show(NotificationType.PopUpWelcome);
        notification.OnButtonClicked.AddListener(notification.Close);
        notification.OnButtonClicked.AddListener(OpenAwarenessNotifier);
        PersistentData.wasWelcomed = true;
    }

    public void OpenAwarenessNotifier()
    {
        ScreenNotification notification = ScreenNotificationHandler.Show(NotificationType.PopUpAwareness);
        notification.OnButtonClicked.AddListener(notification.Close);
    }


    public void OnLocationServiceLost()
    {
        ScreenNotification notification = ScreenNotificationHandler.Show(NotificationType.BannerGPS);
        notification.OnButtonClicked.AddListener(notification.Close);                                   //< These need to be in this order, otherwise it opens the notification when location service fails and then is closed immediately.
        if (!GPSHandler.instance.debugMode)  //> Don't keep on showing banner during GPS debug mode
        notification.OnButtonClicked.AddListener(GPSHandler.instance.RestartLocationService);
    }
}
