//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144), Aleksa Savic (769417)
// Last changed: 04-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationHandler : MonoBehaviour
{
    private DialogueDisplayHelper dialogueDisplayHelper;

    [Header("Visualization Section")]
    [SerializeField]
    private Animator bodyAnimator;

    [SerializeField]
    private Animator faceAnimator;

    private int bodyHasPicture = Animator.StringToHash("HasPicture");   //< bool
    private int bodyIsTurningR = Animator.StringToHash("IsTurningR");   //< bool
    private int bodyIsTurningL = Animator.StringToHash("IsTurningL");   //< bool
    private int bodyHasFinishedWaving = Animator.StringToHash("HasFinishedWaving");   //< Trigger

    private int faceIsTalking = Animator.StringToHash("IsTalking");   //< bool
    private int faceIsHappy = Animator.StringToHash("IsHappy");   //< bool
    private int faceHasFinishedEntryFace = Animator.StringToHash("HasFinishedEntryFace");   //< Trigger

    private void Start()
    {
        dialogueDisplayHelper = FindObjectOfType<DialogueDisplayHelper>();

        if (bodyAnimator == null || faceAnimator == null)
            Debug.LogWarning($"AnimationHelper: You forgot to set the animators in the editor!", this);

        //bodyAnimator.SetBool(faceIsHappy, true);
    }

    public void eAssignAnimators()
    {
        List<AnimatorHelper> animatorHelpers = new List<AnimatorHelper>(FindObjectsOfType<AnimatorHelper>());
        foreach (var entry in animatorHelpers)
        {
            switch (entry.type)
            {
                case AnimatorType.Body:
                    bodyAnimator = entry.animator;
                    break;
                case AnimatorType.Face:
                    faceAnimator = entry.animator;
                    break;
                default:
                    break;
            }
        }
    }
}
