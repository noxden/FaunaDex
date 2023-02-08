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

public enum NotificationType { PopUpWelcome, PopUpAwareness, PopUpScanEnvironment, BannerGPS, OverlayScanning }

public class ScreenNotificationHandler : MonoBehaviour
{
    public static ScreenNotificationHandler instance { set; get; }  //?< Does that instance still exist even if the script is not present in the scene? - If yes, then big bad

    private List<ScreenNotification> notificationQueue;

    // [Header("Generic Notification Prefabs")]
    // [SerializeField]
    // private GameObject PopUpGeneric;

    // [SerializeField]
    // private GameObject OverlayGeneric;

    // [SerializeField]
    // private GameObject BannerGeneric;

    [Header("Prebuilt Notification Prefabs (in Scene)")]
    [SerializeField]
    private GameObject PopUpWelcome;

    [SerializeField]
    private GameObject PopUpAwareness;

    [SerializeField]
    private GameObject PopUpScanEnvironment;

    [SerializeField]
    private GameObject BannerGPS;

    [SerializeField]
    private GameObject OverlayScanning;

    private void Awake()
    {
        //# Singleton Setup 
        if (instance != null)
        {
            Debug.Log($"ScreenNotificationHandler: Another singleton instance already exists.", this);
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        notificationQueue = new List<ScreenNotification>(FindObjectsOfType<ScreenNotification>());

        foreach (var notification in notificationQueue)
        {
            notification.Close();
        }
    }

    /// <summary>
    /// Deprecated method.
    /// </summary>
    // public static void GenerateNotification(NotificationType type)
    // {
    //     //Instantiate(ScreenNotificationHandler.instance.Banner, parent:ScreenNotificationHandler.instance.transform);
    // }

    // public static ScreenNotification GeneratePopUp(string contentText, string buttonText, out UnityEvent OnClick)
    // {
    //     GameObject go = Instantiate(ScreenNotificationHandler.instance.GenericPopUp, parent: ScreenNotificationHandler.instance.transform);
    //     // go.SetActive(false);
    //     ScreenNotification notification = go.GetComponent<ScreenNotification>();
    //     notification.Setup();   //TODO: Fix fields not being set in time.
    //     Debug.Log($"ScreenNotificationHandler has instantiated a new popup: {go.name}", go);

    //     ScreenNotificationHandler.instance.notificationQueue.Add(notification);

    //     //> Set text
    //     notification.contentText = contentText;
    //     notification.buttonText = buttonText;

    //     //> Return values 
    //     OnClick = notification.OnButtonClicked;
    //     return notification;
    // }

    // public static UnityEvent GeneratePopUp(string contentText, string buttonText, out ScreenNotification notification)  //< This is technically an overload
    // {
    //     notification = GeneratePopUp(contentText, buttonText, out UnityEvent Clicked);
    //     return Clicked;
    // }

    // public static ScreenNotification GeneratePopUpWelcome()
    // {
    //     GameObject go = Instantiate(ScreenNotificationHandler.instance.PopUpWelcome, parent: ScreenNotificationHandler.instance.transform);
    //     // go.SetActive(false);
    //     ScreenNotification notification = go.GetComponent<ScreenNotification>();
    //     Debug.Log($"ScreenNotificationHandler has instantiated a new popup: {go.name}", go);

    //     //ScreenNotificationHandler.instance.notificationQueue.Add(notification);
    //     return notification;
    // }

    public static ScreenNotification Show(NotificationType type)
    {
        GameObject go = null;

        switch (type)
        {
            case NotificationType.PopUpWelcome:
                go = ScreenNotificationHandler.instance.PopUpWelcome;
                break;
            case NotificationType.BannerGPS:
                go = ScreenNotificationHandler.instance.BannerGPS;
                break;
            case NotificationType.PopUpAwareness:
                go = ScreenNotificationHandler.instance.PopUpAwareness;
                break;
            case NotificationType.PopUpScanEnvironment:
                go = ScreenNotificationHandler.instance.PopUpScanEnvironment;
                break;
            case NotificationType.OverlayScanning:
                go = ScreenNotificationHandler.instance.OverlayScanning;
                break;
            default:
                break;
        }

        Debug.Log($"ScreenNotificationHandler: Showing ScreenNotification {go.name}.", go);
        if (go != null)
            go.SetActive(true);

        return go.GetComponent<ScreenNotification>();
    }

    public static void Close(ScreenNotification notification)
    {
        notification.gameObject.SetActive(false);
        Debug.Log($"ScreenNotificationHandler: Closing ScreenNotification {notification.name}.", notification);
        notification.OnButtonClicked?.RemoveAllListeners();   //< Not needed, as they are not destroyed anymore
        // //ScreenNotificationHandler.instance.notificationQueue.Remove(notification);
        // Destroy(notification.gameObject);
    }
}
