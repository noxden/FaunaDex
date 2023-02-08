//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 07-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    //# Tutorial Flags 
    public static bool didShowTutorial
    {
        get
        {
            return PlayerPrefs.GetInt(PlayerPrefsKey.didShowTutorial, 0) == 1;  //< "PlayerPrefsKey.didShowTutorial" is just a String variable (see line 61)
        }
        set
        {
            if (value == true)
                PlayerPrefs.SetInt(PlayerPrefsKey.didShowTutorial, 1);
            else
                PlayerPrefs.SetInt(PlayerPrefsKey.didShowTutorial, 0);
        }
    }
    //> Not needed anymore, but as it is a function without any parameters, which might be useful if need to be triggered by a button?
    // public static void SetTutorialAsShown()      
    // {
    //     PlayerPrefs.SetInt(PlayerPrefsKey.didShowTutorial, 1);
    // }

    public static int questStage
    {
        get
        {
            return PlayerPrefs.GetInt(PlayerPrefsKey.questStage, 0);
        }
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKey.questStage, value);
        }
    }

    public static void DeleteSaveFile()
    {
        didShowTutorial = false;
    }

    //* Additional info:
    // PlayerPrefs supports the following functions:
    // PlayerPrefs.SetInt()
    // PlayerPrefs.SetFloat()
    // PlayerPrefs.SetString()
}

public class PlayerPrefsKey
{
    public static string didShowTutorial = "didShowTutorial";
    public static string questStage = "questStage";
}
