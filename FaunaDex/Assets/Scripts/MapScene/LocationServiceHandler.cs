//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 24-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LocationServiceHandler : MonoBehaviour
{
    //# Public Variables 
    public static LocationServiceHandler instance { set; get; }

    [Header("DEBUG AREA")]
    [SerializeField] [Range(49.89f,49.92f)]
    private float debugLatitude = 0.0f;
    [SerializeField] [Range(8.85f,8.87f)]
    private float debugLongitude = 0.0f;

    public float lastLatitude
    {
        get
        {
            if (Location.IsLocationServiceRunning)
                return Location.latitude;
            else
                return debugLatitude;
        }
    }

    public float lastLongitude
    {
        get
        {
            if (Location.IsLocationServiceRunning)
                return Location.longitude;
            else
                return debugLongitude;
        }
    }

    //# Private Variables 

    //# Custom Events 
    [Space(20)]
    public UnityEvent OnGPSSuccess;
    public UnityEvent OnGPSFailure;

    //# Monobehaviour Events 
    private void Awake()
    {
        //# Singleton Setup 
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        instance = this;

#if UNITY_EDITOR
        debugLatitude = 49.902030f;
        debugLongitude = 8.855255f;
#endif
    }

    private IEnumerator Start()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log($"GPS is currently disabled on your device.");
            OnGPSFailure.Invoke();
            yield break;
        }


        // Starts the location service.
        Input.location.Start(desiredAccuracyInMeters: 15.0f, updateDistanceInMeters: 10.0f);

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            Debug.Log($"Waiting for {maxWait} more seconds.");
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            Debug.Log("Location Service has been started successfully: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            OnGPSSuccess.Invoke();
        }

        // Stops the location service if there is no need to query location updates continuously.
        Debug.Log($"Stopping location service.");
        Input.location.Stop();
    }

    //# Public Methods 
    public bool TryStartLocationService()
    {
        Start();
        return Input.location.isEnabledByUser;
    }

    //# Private Methods 

    //# Input Event Handlers 
}