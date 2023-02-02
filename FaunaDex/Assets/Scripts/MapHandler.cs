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
    [SerializeField]
    private MapPlayer player;

    [SerializeField]
    private Map map;

    [SerializeField]
    private Vector2 pixelPerMeterRatio = new Vector2(1000000.0f, 10000.0f);

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
        //! Longitude and latitude just have different scopes... Lat is between 45 and 50 while Long is between 8 and 9...
        Vector2 adjustedMapPosition = ((player.realWorldLocation - map.realWorldZero) * pixelPerMeterRatio * map.transform.localScale);
        // Debug.Log($"Current map offset: ({(player.realWorldLocation.x) - map.realWorldZero.x}, {player.realWorldLocation.y - map.realWorldZero.y})");
        // Debug.Log($"Adjusted map position: {adjustedMapPosition}", this);
        map.transform.localPosition = adjustedMapPosition;
    }
}
