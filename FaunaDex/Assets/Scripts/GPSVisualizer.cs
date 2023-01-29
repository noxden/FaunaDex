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
    private TextMeshProUGUI tIsEnabled;
    [SerializeField]
    private TextMeshProUGUI tLatitude;
    [SerializeField]
    private TextMeshProUGUI tLongitude;
    [SerializeField]
    private TextMeshProUGUI tStatus;

    void Update()
    {
        tIsEnabled.text = Input.location.isEnabledByUser.ToString();
        tLatitude.text = Input.location.lastData.latitude.ToString();
        tLongitude.text = Input.location.lastData.longitude.ToString();
        tStatus.text = Input.location.status.ToString();
    }
}
