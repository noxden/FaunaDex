//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 01-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void IntDelegate(int integer);

public class PersistentSaveData : MonoBehaviour
{
    public static PersistentSaveData instance { set; get; }
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
    }

    private void Start()
    {
        questStage_Otto = 0;
    }
}
