//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 27-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapPlayer : MonoBehaviour
{
    public Scene? selectedScene
    {
        get
        {
            if (scenesOfPOIsInRange.Count > 0)
                return scenesOfPOIsInRange[scenesOfPOIsInRange.Count - 1];
            return null;
        }
    }

    [SerializeField]
    private List<Scene> scenesOfPOIsInRange;

    //# Custom Events 
    [Space(20)]
    public UnityEvent OnHasSelectedScene;   //?< Could also have the selected scene as parameter?
    public UnityEvent OnNoSelectedScene;

    //# Monobehaviour Events 
    private void Update()
    {
        Vector3 scaledGPSLocation = new Vector3(LocationServiceHandler.instance.lastLatitude * Settings.locationScaleFaktor, this.transform.position.y, LocationServiceHandler.instance.lastLongitude * Settings.locationScaleFaktor);
        this.gameObject.transform.position = scaledGPSLocation;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, 50.0f /*,LayerMask.GetMask(LayerMask.LayerToName(15))*/ ))  //< "~LayerMask.GetMask("Item")" creates a Layermask that allows everything but the "Item" layer.
        {
            Debug.Log($"Raycast hit {hit.collider.name}.");
            if (hit.collider.gameObject.layer == 15)
            {
                Debug.Log($"{hit.collider.name} is on layer {LayerMask.LayerToName(hit.collider.gameObject.layer)}.");
                PointOfInterest poi = hit.collider.transform.GetComponentInParent<PointOfInterest>();
                AddSceneToList(poi.linkedScene);
            }
            else if (selectedScene.HasValue)
            {
                Debug.Log($"{hit.collider.name}'s layer ({LayerMask.LayerToName(hit.collider.gameObject.layer)}) does not match {LayerMask.LayerToName(hit.collider.gameObject.layer)}.");
                RemoveSceneFromList((Scene)selectedScene);
            }
            //Debug.Log($"Player's raycast has hit the VPS Location Highlight.");
        }
        else
        {
            //> Clear the previously selected scene
            if (selectedScene.HasValue)
            {
                RemoveSceneFromList((Scene)selectedScene);
            }

            Debug.Log($"Raycast missed.");
        }
    }

    //# Private Methods 
    private void AddSceneToList(Scene scene)
    {
        if (scenesOfPOIsInRange.Contains(scene))    //< If list already contains this entry, don't change anything and just skip this method call.
            return;

        scenesOfPOIsInRange.Add(scene);
        Debug.Log($"Added Scene \"{scene}\" to list.");

        if (selectedScene != null)
        {
            // Call ActivateButton Event
            OnHasSelectedScene.Invoke();
        }
    }

    private void RemoveSceneFromList(Scene scene)
    {
        if (scenesOfPOIsInRange.Count <= 0)  //< There is no scene to remove anymore. Something unexpected must have happened to lead to this
            return;

        scenesOfPOIsInRange.RemoveAll(x => x == scene);
        Debug.Log($"Removed Scene \"{scene}\" from list.");
        if (selectedScene == null)
        {
            // Call DeactivateButton Event
            OnNoSelectedScene.Invoke();
        }
    }

    //# Event Handlers 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PointOfInterest>(out PointOfInterest poi))
        {
            AddSceneToList(poi.linkedScene);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PointOfInterest>(out PointOfInterest poi))
        {
            RemoveSceneFromList(poi.linkedScene);
        }
    }
}
