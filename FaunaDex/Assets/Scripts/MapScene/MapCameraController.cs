//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 26-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraController : MonoBehaviour
{
    //# Public Variables 
    public bool isLocked;

    //# Private Variables 
    private MapPlayer player;
    private Transform anchor;

    //# Monobehaviour Events 
    void Start()
    {
        player = FindObjectOfType<MapPlayer>();
        GameObject go = new GameObject("CameraAnchor");
        anchor = go.transform;

        isLocked = true;
    }

    void Update()
    {
        transform.position = new Vector3(anchor.position.x, this.transform.position.y, anchor.position.z);

        if (isLocked)
            anchor.position = player.transform.position;
        else
        {

        }
    }
}
