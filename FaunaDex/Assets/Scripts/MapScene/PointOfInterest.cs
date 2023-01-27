//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 27-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! NEEDS HEAVY REFACTORING. ALL OF THIS SHOULD BE DETERMINED BY THE PLAYER, NOT THE POI!

public class PointOfInterest : MonoBehaviour
{
    public Scene linkedScene;

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.TryGetComponent<PlayerMapMarker>(out PlayerMapMarker player))
    //     {
    //         Debug.Log($"Player entered zone of {this.name}.");
    //         player.SceneToLoadOnButtonPress = linkedScene;
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.TryGetComponent<PlayerMapMarker>(out PlayerMapMarker player))
    //     {
    //         Debug.Log($"Player exited zone of {this.name}.");
    //         player.SceneToLoadOnButtonPress = null;
    //     }
    // }
}