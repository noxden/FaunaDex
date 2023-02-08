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

public enum NotificationType { }

public class ScreenNotificationHandler : MonoBehaviour
{
    public static ScreenNotificationHandler instance { set; get; }  //?< Does that instance still exist even if the script is not present in the scene? - If yes, then big bad

    private List<ScreenNotification> notificationQueue;

    [Header("Notification Prefabs")]
    [SerializeField]
    private GameObject PopUp;

    [SerializeField]
    private GameObject Overlay;

    [SerializeField]
    private GameObject Banner;

    private void Awake()
    {
        //# Singleton Setup 
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;
    }

    /// <summary>
    /// Deprecated method.
    /// </summary>
    public static void GenerateNotification(NotificationType type)
    {
        //Instantiate(ScreenNotificationHandler.instance.Banner, parent:ScreenNotificationHandler.instance.transform);
    }

    public static ScreenNotification GeneratePopUp(string contentText, string buttonText, out UnityEvent OnClick)
    {
        GameObject go = Instantiate(ScreenNotificationHandler.instance.PopUp, parent: ScreenNotificationHandler.instance.transform);
        // go.SetActive(false);
        ScreenNotification notification = go.GetComponent<ScreenNotification>();
        notification.Setup();   //TODO: Fix fields not being set in time.
        Debug.Log($"ScreenNotificationHandler has instantiated a new popup: {go.name}", go);

        ScreenNotificationHandler.instance.notificationQueue.Add(notification);

        //> Set text
        notification.contentText = contentText;
        notification.buttonText = buttonText;

        //> Return values 
        OnClick = notification.OnButtonClicked;
        return notification;
    }

    public static UnityEvent GeneratePopUp(string contentText, string buttonText, out ScreenNotification notification)  //< This is technically an overload
    {
        notification = GeneratePopUp(contentText, buttonText, out UnityEvent Clicked);
        return Clicked;
    }

    public static void Close(ScreenNotification notification)
    {
        Debug.Log($"ScreenNotificationHandler: Closing ScreenNotification {notification.name}.", notification);
        ScreenNotificationHandler.instance.notificationQueue.Remove(notification);
        Destroy(notification.gameObject);
    }
}
