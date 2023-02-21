using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGOverrideGPSLocation : MonoBehaviour
{
    public Vector2 Otto = new Vector2(49.902f, 8.85475f);
    public Vector2 Dragonfly = new Vector2(49.90143f, 8.85816f);

    private void Start()
    {
        // Debug.LogWarning($"DEBUGOverrideGPSLocation is currently enabled. GPSHandler.debugMode will now be activated.");
        // GPSHandler.instance.debugMode = true;
    }

    public void TPToOtto()
    {
        if (GPSHandler.instance.debugMode != true)
            GPSHandler.instance.debugMode = true;

        Debug.Log($"DEBUGOverrideGPSLocation: Teleported player to Otto");
        GPSHandler.instance.debugLatitude = Otto.x;
        GPSHandler.instance.debugLongitude = Otto.y;
    }

    public void TPToDragonfly()
    {
        if (GPSHandler.instance.debugMode != true)
            GPSHandler.instance.debugMode = true;

        Debug.Log($"DEBUGOverrideGPSLocation: Teleported player to Dragonfly");
        GPSHandler.instance.debugLatitude = Dragonfly.x;
        GPSHandler.instance.debugLongitude = Dragonfly.y;
    }
}
