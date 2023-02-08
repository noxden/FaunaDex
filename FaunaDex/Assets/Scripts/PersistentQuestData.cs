//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 06-02-23
//================================================================
//* QuestStage 0 = Started App
//* QuestStage 1 = Accepted Quest from Otto
//* QuestStage 2 = Took Photo of Dragonfly
//* QuestStage 3 = Handed over Photo to Otto, Took Photo of Otto
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void IntDelegate(int integer);

public class PersistentQuestData : MonoBehaviour
{
    public static PersistentQuestData instance { set; get; }
    public IntDelegate OnQuestUpdated_Otto;

    [SerializeField]
    [Tooltip("Only for visualization")]
    private int _questStage_Otto;
    public int questStage_Otto
    {
        get
        {
            return _questStage_Otto;
        }
        set
        {
            _questStage_Otto = value;
            SaveDataManager.questStage = questStage_Otto;
            OnQuestUpdated_Otto?.Invoke(questStage_Otto);
        }
    }

    //# Monobehaviour Events 
    private void Awake()
    {
        //# Singleton Setup 
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        instance = this;

        //# Read save file 
        questStage_Otto = SaveDataManager.questStage;
        Debug.Log($"Loaded save file: QuestStage is now {questStage_Otto}.", this);
    }
}
