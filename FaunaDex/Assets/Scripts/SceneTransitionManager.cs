//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 06-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene { Map, Otter, Dragonfly, QuestTracker }

public delegate void SceneDelegate(Scene scene);

public class SceneTransitionManager
{
    
    public static SceneDelegate OnSceneChanged;

    //# Public Methods 
    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadSceneAsync(ResolveSceneName(scene));
        OnSceneChanged?.Invoke(scene);
    }

    //# Private Methods 
    private static string ResolveSceneName(Scene scene)
    {
        switch (scene)
        {
            case Scene.Map:
                return "GPSMapScene";
            case Scene.Otter:
                return "OttoScene";
            case Scene.Dragonfly:
                return "DragonflySceneNew";
            case Scene.QuestTracker:
                return "QuestTracker";
        }
        return "";
    }
}