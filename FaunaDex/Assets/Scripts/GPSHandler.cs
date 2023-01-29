//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 29-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GPSHandler : MonoBehaviour
{
    //# Public Variables 
    public static GPSHandler instance { set; get; }

    [SerializeField]
    private float latitude;
    [SerializeField]
    private float longitude;

    [Space(20)]
    [Header("DEBUG SECTION")]
    [SerializeField]
    [Range(52.04f, 47.77f)]
    private float debugLatitude = 49.901657f;
    [SerializeField]
    [Range(5.38f, 12.31f)]
    private float debugLongitude = 8.855605f;

    //# Private Variables 

    //# Custom Events 
    [Space(20)]
    public UnityEvent OnGPSSuccess;
    public UnityEvent OnGPSFailure;
    public UnityEvent<Vector2> OnGPSUpdate;

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
        Input.location.Start(desiredAccuracyInMeters: 5.0f, updateDistanceInMeters: 10.0f);

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
            OnGPSFailure.Invoke();
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            OnGPSFailure.Invoke();
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            Debug.Log("Location Service has been started successfully: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            OnGPSSuccess.Invoke();
        }
    }

    private void FixedUpdate()
    {
#if UNITY_EDITOR
        DebugCheckForLocationUpdate();
#elif !UNITY_EDITOR
        CheckForLocationUpdate();
#endif
    }

    //# Public Methods 
    public void StartLocationService()
    {
        StopCoroutine(Start());
        StartCoroutine(Start());
    }

    public void StopLocationService()
    {
        Debug.Log($"Stopping location service.");
        Input.location.Stop();
    }

    //# Private Methods 
    private void CheckForLocationUpdate()
    {
        Debug.Log($"GPSHandler: Checking for new location update.", this);
        if (Input.location.status != LocationServiceStatus.Running)
        {
            Debug.LogWarning($"GPSHandler: LocationService is not running.", this);
            return;
        }

        float newLatitude = Input.location.lastData.latitude;
        float newLongitude = Input.location.lastData.longitude;

        if (latitude != newLatitude || longitude != newLongitude)
        {
            Debug.Log($"GPSHandler: Detected location update!", this);
            latitude = newLatitude;
            longitude = newLongitude;
            OnGPSUpdate.Invoke(new Vector2(latitude, longitude));
        }
    }

    private void DebugCheckForLocationUpdate()
    {
        if (debugLatitude != latitude || debugLongitude != longitude)
        {
            Debug.Log($"GPSHandler: Detected debug location update!", this);
            latitude = debugLatitude;
            longitude = debugLongitude;
            OnGPSUpdate.Invoke(new Vector2(latitude, longitude));
        }
    }

    //# Input Event Handlers 
}