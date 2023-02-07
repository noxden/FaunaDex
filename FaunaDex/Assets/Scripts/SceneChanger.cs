using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneToMap()
    {
        SceneTransitionManager.LoadScene(Scene.Map);
    }

    public void ChangeSceneToOttoMode()
    {
        SceneTransitionManager.LoadScene(Scene.Otter);
    }

    public void ChangeSceneToDragonflyMode()
    {
        SceneTransitionManager.LoadScene(Scene.Dragonfly);
    }

    public void ChangeSceneToPlayerSelection()
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
