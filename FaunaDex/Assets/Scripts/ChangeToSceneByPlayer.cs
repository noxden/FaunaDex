//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 29-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToSceneByPlayer : MonoBehaviour
{
    public void ChangeToSceneSelectedByPlayer()
    {
        MapPlayer player = FindObjectOfType<MapPlayer>();
        if (player?.selectedScene != null)
        {
            Scene selectedScene = (Scene)player.selectedScene;
            SceneTransitionManager.LoadScene(selectedScene);
        }
        else
        {
            Debug.Log($"ChangeToScene: No selected scene could be found.", this);
        }
    }
}
