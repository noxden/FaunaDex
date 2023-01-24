using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! NEEDS HEAVY REFACTORING. ALL OF THIS SHOULD BE DETERMINED BY THE PLAYER, NOT THE POI!

public class PointOfInterest : MonoBehaviour
{
    public Scene SceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMapMarker>(out PlayerMapMarker player))
        {
            player.SceneToLoadOnButtonPress = SceneToLoad;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMapMarker>(out PlayerMapMarker player))
        {
            player.SceneToLoadOnButtonPress = null;
        }
    }
}