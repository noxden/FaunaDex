//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 29-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    //# Public Variables 
    public static MapHandler instance { set; get; }

    //# Private Variables 
    private MapPlayer player;
    private Map map;

    [SerializeField]
    private float pixelPerMeterRatio = 500.0f;

    private void Awake()
    {
        //# Singleton Setup 
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        player = FindObjectOfType<MapPlayer>();
        map = FindObjectOfType<Map>();
    }

    public void OnGPSUpdate(Vector2 location)
    {
        player.realWorldLocation = location;
        UpdateMapPosition();
    }

    private void UpdateMapPosition()
    {
        Vector2 adjustedMapPosition = ((player.realWorldLocation - map.realWorldZero) * pixelPerMeterRatio + new Vector2(Screen.width / 2, Screen.height / 2));
        Debug.Log($"Adjusted map position: {adjustedMapPosition}", this);
        map.transform.position = adjustedMapPosition;
    }
}
