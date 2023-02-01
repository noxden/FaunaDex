//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 01-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestUpdateRelay : MonoBehaviour
{

    [SerializeField]
    private int questStageThreshold;

    [Space(20)]
    public UnityEvent<int> OnThresholdReached;

    private void OnEnable() => PersistentQuestData.instance.OnQuestUpdated_Otto += CheckQuestStage;
    private void OnDisable() => PersistentQuestData.instance.OnQuestUpdated_Otto -= CheckQuestStage;

    private void Start()
    {
        CheckQuestStage(PersistentQuestData.instance.questStage_Otto);
    }

    private void CheckQuestStage(int stage)
    {
        if (stage >= questStageThreshold)
            OnThresholdReached.Invoke(stage);
    }
}
