//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 24-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Location
{
    public static bool IsLocationServiceRunning
    {
        get
        {
            return Input.location.status == LocationServiceStatus.Running;
        }
    }

    public static float latitude
    {
        get
        {
            if (Input.location.status == LocationServiceStatus.Running)
                return Input.location.lastData.latitude;
            return 0;
        }
    }
    
    public static float longitude
    {
        get
        {
            if (Input.location.status == LocationServiceStatus.Running)
                return Input.location.lastData.longitude;
            return 0;
        }
    }
    public static float horizontalAccuracy
    {
        get
        {
            if (Input.location.status == LocationServiceStatus.Running)
                return Input.location.lastData.horizontalAccuracy;
            return 0;
        }
    }
    public static double timestamp
    {
        get
        {
            if (Input.location.status == LocationServiceStatus.Running)
                return Input.location.lastData.timestamp;
            return 0;
        }
    }
}
