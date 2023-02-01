//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 01-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeQuestStageButton : MonoBehaviour
{
    [SerializeField]
    private int requiredQuestStage;

    [SerializeField]
    private int changeToStage;

    public void OnButtonPressed()
    {
        if (PersistentSaveData.instance.questStage_Otto == requiredQuestStage)
        {
            PersistentSaveData.instance.questStage_Otto = changeToStage;
        }
    }
}
