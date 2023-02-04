//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 04-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimatorType { Body, Face }
public class AnimatorHelper : MonoBehaviour
{
    public Animator animator { get; private set; }
    public AnimatorType type;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
            Debug.LogWarning($"The animator field on {this.gameObject.name} is still null!");
    }
}
