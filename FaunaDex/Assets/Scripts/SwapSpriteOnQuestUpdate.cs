//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 01-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapSpriteOnQuestUpdate : MonoBehaviour
{
    [Tooltip("Link this to the sprite you want to change.")]
    [SerializeField]
    private Image spriteField;

    [SerializeField]
    private Sprite initialSprite;

    [SerializeField]
    private Sprite finalSprite;

    [SerializeField]
    private int requiredQuestStage;

    private void OnEnable() => PersistentSaveData.instance.OnQuestUpdated_Otto += OnQuestUpdated;
    private void OnDisable() => PersistentSaveData.instance.OnQuestUpdated_Otto -= OnQuestUpdated;

    private void Start()
    {
        CheckQuestStage();
    }

    public void OnQuestUpdated(int newQuestState)
    {
        Debug.Log($"Received Quest Update on {this.name}.");
        CheckQuestStage();        
    }

    private void CheckQuestStage()
    {
        if (PersistentSaveData.instance.questStage_Otto < requiredQuestStage)
            spriteField.sprite = initialSprite;
        else
            spriteField.sprite = finalSprite;
    }
}
