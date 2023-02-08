//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 06-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLibrary : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Only for visualization")]
    private int questStage = 0;

    [SerializeField]
    private List<Dialogue> Dialogues = new List<Dialogue>(4);

    [SerializeField]
    private Dialogue ErrorDialogue;

    private void OnEnable() => PersistentQuestData.instance.OnQuestUpdated_Otto += SetQuestStage;
    private void OnDisable() => PersistentQuestData.instance.OnQuestUpdated_Otto -= SetQuestStage;

    private void Start()
    {
        questStage = PersistentQuestData.instance.questStage_Otto;
    }

    public void SetQuestStage(int newStage)
    {
        questStage = newStage;
    }

    public List<DialogueEntry> GetDialogueEntries()
    {
        if (questStage >= Dialogues.Count)
            return ErrorDialogue.dialogueEntries;

        return Dialogues[questStage].dialogueEntries;
    }
}
