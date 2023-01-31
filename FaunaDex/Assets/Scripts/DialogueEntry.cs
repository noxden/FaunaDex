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
