//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 29-01-23
//! FOR DEBUG PURPOSES ONLY!
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GPSVisualizer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tIsEnabled = null;
    [SerializeField]
    private TextMeshProUGUI tLatitude = null;
    [SerializeField]
    private TextMeshProUGUI tLongitude = null;
    [SerializeField]
    private TextMeshProUGUI tStatus = null;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        GPSHandler.instance.OnGPSUpdate.AddListener(UpdateText);
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    private void OnDestroy()
    {
        GPSHandler.instance.OnGPSUpdate.RemoveListener(UpdateText);
    }

    void UpdateText(Vector2 _)
    {
        if (tIsEnabled != null)
            tIsEnabled.text = Input.location.isEnabledByUser.ToString();
        if (tLatitude != null)
            tLatitude.text = Input.location.lastData.latitude.ToString();
        if (tLongitude != null)
            tLongitude.text = Input.location.lastData.longitude.ToString();
        if (tStatus != null)
            tStatus.text = Input.location.status.ToString();
    }
}
