using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeSceneToMain()
    {
        SceneTransitionManager.LoadScene(Scene.Map);
    }

    public void ChangeSceneToOttoMode()
    {
        SceneTransitionManager.LoadScene(Scene.Otter);
    }
}
