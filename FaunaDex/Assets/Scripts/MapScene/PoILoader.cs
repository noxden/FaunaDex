//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 27-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoILoader : MonoBehaviour
{
    public List<PointOfInterestData> pointOfInterestDatas;

    private void Start()
    {
        foreach (PointOfInterestData poiData in pointOfInterestDatas)
        {
            GameObject go = Instantiate(poiData.markerPrefab);
            //go.transform.localScale /= Settings.locationScaleFaktor;
            go.transform.position = new Vector3(poiData.latitude*Settings.locationScaleFaktor, 0, poiData.longitude*Settings.locationScaleFaktor);
            go.name = poiData.name;
            go.GetComponent<PointOfInterest>().linkedScene = poiData.SceneToLoad;
        }
    }
}
