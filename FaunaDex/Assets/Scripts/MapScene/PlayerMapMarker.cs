//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 24-01-23
//================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapMarker : MonoBehaviour
{
    public Scene? SceneToLoadOnButtonPress;  //If this is not null, enable AR Camera Button
    
    private void Start()
    {
        // GameObject playerMarker = Instantiate(markerPrefab);
        this.gameObject.transform.localScale /= Settings.locationScaleFaktor;
        this.gameObject.name = "Player Marker";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Player read: lastLatitude {LocationServiceHandler.instance.lastLatitude}, lastLongitude {LocationServiceHandler.instance.lastLongitude}", this);
        this.gameObject.transform.position = new Vector3(LocationServiceHandler.instance.lastLatitude*Settings.locationScaleFaktor, 0, LocationServiceHandler.instance.lastLongitude*Settings.locationScaleFaktor);
    
        if (Input.GetMouseButtonDown(0) && SceneToLoadOnButtonPress != null)
        {
            SceneTransitionManager.LoadScene((Scene)SceneToLoadOnButtonPress);
        }
    }
}
