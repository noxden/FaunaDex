using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.ARDK.AR.WayspotAnchors;
using Niantic.ARDKExamples.RemoteAuthoring;
using UnityEngine.Events;


public class LocationLoader : MonoBehaviour
{
    private enum VPSLocation { MediaColumn, FireExit }
    public static LocationLoader instance { get; set; }
    private LocationManifestManager locationManifestManager;

    [SerializeField]
    private VPSLocation selectedLocation;

    //# Custom Events 
    [Space(10)]
    [Header("Events Section")]
    [Space(5)]
    public UnityEvent OnLocalizationSuccess;
    public UnityEvent OnLocalizationFailure;

    private void Awake()
    {
        //# Singleton Setup 
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(this.gameObject);
    }

    private void Start()
    {
        locationManifestManager = LocationManifestManager.Instance;
        locationManifestManager.AddLocalizationStatusListener(LocationStatusChanged);
    }

    public void Localize()
    {
        locationManifestManager.LoadWayspotAnchors((int)selectedLocation);
    }

    private void LocationStatusChanged(LocalizationStateUpdatedArgs args)
    {
        string text = "Localization Status: ";
        if (args != null)
        {
            text += $"{args.State} " +
              (args.State == LocalizationState.Failed ? $"(Reason: {args.FailureReason})" : "");
            Debug.Log($"{text}");
        }

        //> Invoke Events based on LocalizationState
        if (args?.State == LocalizationState.Localized)
        {
            OnLocalizationSuccess?.Invoke();
        }
        else if (args?.State == LocalizationState.Failed)
        {
            OnLocalizationFailure?.Invoke();
        }
    }
}
