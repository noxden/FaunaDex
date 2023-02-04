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
