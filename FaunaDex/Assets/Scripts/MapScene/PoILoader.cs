//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 24-01-23
//================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoILoader : MonoBehaviour
{
    public List<PointOfInterestData> pointOfInterests;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        foreach (PointOfInterestData poi in pointOfInterests)
        {
            GameObject go = Instantiate(poi.markerPrefab);
            go.transform.localScale /= Settings.locationScaleFaktor;
            go.transform.position = new Vector3(poi.latitude*Settings.locationScaleFaktor, 0, poi.longitude*Settings.locationScaleFaktor);
            go.name = poi.name;
            go.GetComponent<PointOfInterest>().SceneToLoad = poi.SceneToLoad;
        }
    }
}
