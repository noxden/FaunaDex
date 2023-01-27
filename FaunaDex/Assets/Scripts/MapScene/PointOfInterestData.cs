//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 24-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Point of Interest", menuName = "Scriptable/Point of Interest")]
public class PointOfInterestData : ScriptableObject
{
    public GameObject markerPrefab;
    public float latitude;
    public float longitude;
    public Scene SceneToLoad;
    
}
