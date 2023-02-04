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

    [SerializeField]
    private bool isWelcoming = true;

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
    }

    public void AssignAnimators()
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

    public void OnTextStartedDisplaying(List<Expression> expressions)
    {
        if (isWelcoming)
            StopWelcoming();

        IsTalkingTrue();

        foreach (var expression in expressions)
        {
            switch (expression)
            {
                case Expression.Neutral:
                    IsHappyFalse();
                    break;
                case Expression.Happy:
                    IsHappyTrue();
                    break;
                case Expression.Idle:
                    AwaitsPictureFalse();
                    break;
                case Expression.Awaiting:
                    AwaitsPictureTrue();
                    break;
            }
        }

        if (bodyAnimator == null || faceAnimator == null)
            Debug.LogError($"AnimationHelper: The animators could not be set!", this);
    }

    public void OnTextFinishedDisplaying()
    {
        IsTalkingFalse();
    }

    private void StopWelcoming()
    {
        bodyAnimator.SetTrigger(bodyHasFinishedWaving);
        faceAnimator.SetTrigger(faceHasFinishedEntryFace);
        isWelcoming = false;
    }

    private void IsTalkingTrue()
    {
        faceAnimator.SetBool(faceIsTalking, true);
    }
    private void IsTalkingFalse()
    {
        faceAnimator.SetBool(faceIsTalking, false);
    }

    private void IsHappyTrue()
    {
        faceAnimator.SetBool(faceIsHappy, true);
    }
    private void IsHappyFalse()
    {
        faceAnimator.SetBool(faceIsHappy, false);
    }


    private void AwaitsPictureTrue()
    {
        bodyAnimator.SetBool(bodyHasPicture, true);
    }
    private void AwaitsPictureFalse()
    {
        bodyAnimator.SetBool(bodyHasPicture, false);
    }
}
