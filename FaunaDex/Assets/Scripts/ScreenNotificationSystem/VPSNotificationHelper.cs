using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSNotificationHelper : MonoBehaviour
{
    private void Start()
    {
        OpenARPopup();
    }

    public void OpenARPopup()
    {
        ScreenNotification notification = ScreenNotificationHandler.Show(NotificationType.PopUpScanEnvironment);
        LocationLoader locationLoader = FindObjectOfType<LocationLoader>();
        notification.OnButtonClicked.AddListener(notification.Close);
        notification.OnButtonClicked.AddListener(OpenScanningOverlay);
        notification.OnButtonClicked.AddListener(locationLoader.Localize);
    }

    public void OpenScanningOverlay()
    {
        ScreenNotification notification = ScreenNotificationHandler.Show(NotificationType.OverlayScanning);
    }
}
