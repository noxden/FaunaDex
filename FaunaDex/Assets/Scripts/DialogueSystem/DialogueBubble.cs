//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 03-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueBubble : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private new BoxCollider collider;
    private GameObject dialogueAnchor;

    //# Custom Events 
    [Header("Events Section")]
    [Space(5)]
    public UnityEvent OnAnchorFound;    //?< This is where Otto's starting animation could be hooked up to

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        collider = GetComponent<BoxCollider>();

        Hide();
        AttachToAnchor();
    }

    private void Update()
    {
        if (dialogueAnchor == null)
            AttachToAnchor();
    }

    private void AttachToAnchor()
    {
        dialogueAnchor = GameObject.FindWithTag("DialogueAnchor");
        if (dialogueAnchor != null)
        {
            this.transform.SetParent(dialogueAnchor.transform, false);
            Show();
            OnAnchorFound.Invoke();
        }
    }

    public void Show()
    {
        collider.enabled = true;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void Hide()
    {
        collider.enabled = false;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
