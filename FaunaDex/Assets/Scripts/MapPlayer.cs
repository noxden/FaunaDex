//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 29-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapPlayer : MonoBehaviour
{
    //# Public Variables 
    [SerializeField]
    public Vector2 realWorldLocation;

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
    public UnityEvent OnOneSceneSelected;   //? Naming
    public UnityEvent OnZeroSceneSelected;

    //# Monobehaviour Events 
    private void Start()
    {
        OnZeroSceneSelected.Invoke();   //< Just to notify everything that is subscribed to this event, that they should enter their "no scene selected" state.
    }

    //# Private Methods 
    private void AddSceneToList(Scene scene)
    {
        if (scenesOfPOIsInRange.Contains(scene))    //< If list already contains this entry, don't add it again 
            return;                                 //  and instead just skip this method call.

        scenesOfPOIsInRange.Add(scene);
        Debug.Log($"Added Scene \"{scene}\" to list.");

        if (selectedScene != null)
        {
            // Call ActivateButton Event
            OnOneSceneSelected.Invoke();
        }
    }

    private void RemoveSceneFromList(Scene scene)
    {
        if (scenesOfPOIsInRange.Count <= 0)  //< There is no scene to remove anymore. Something unexpected must have happened to lead to this. Even though such a case would
            return;                          //  not break the following RemoveAll(), this guard clause will just prevent unnecessary execution of that code.

        scenesOfPOIsInRange.RemoveAll(x => x == scene);
        Debug.Log($"Removed Scene \"{scene}\" from list.");
        if (selectedScene == null)
        {
            // Call DeactivateButton Event
            OnZeroSceneSelected.Invoke();
        }
    }


    //# Input Event Handlers 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.TryGetComponent<VPSArea>(out VPSArea wayspot))
        {
            //Debug.Log($"Player collided with VPSArea for Scene {wayspot.linkedScene}.", this);
            AddSceneToList(wayspot.linkedScene);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.parent.TryGetComponent<VPSArea>(out VPSArea wayspot))
        {
            //Debug.Log($"Player finished colliding with VPSArea for Scene {wayspot.linkedScene}.", this);
            RemoveSceneFromList(wayspot.linkedScene);
        }
    }
}
