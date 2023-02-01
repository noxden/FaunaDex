//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 31-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueEntry", menuName = "Scriptable/DialogueEntry")]
public class DialogueEntry : ScriptableObject
{
    public string speaker;
     [TextArea(1,5)]
    public string text;
}
