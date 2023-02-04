//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 04-02-23
//================================================================
//* Keep in mind, dialogue entries with an empty name will not be
//* displayed and will also not cause any animations to play.
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Expression { Neutral, Happy, Idle, Awaiting }   //< Because the talking animation is controlled by the DialogueDisplayHelper

[CreateAssetMenu(fileName = "DialogueEntry", menuName = "Scriptable/DialogueEntry")]
public class DialogueEntry : ScriptableObject
{
    public string speaker;
    [TextArea(1, 5)]
    public string text;
    public List<Expression> expressions;
}
