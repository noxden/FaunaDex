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

public class SwitchSprite : MonoBehaviour
{
    [Tooltip("Link this to the sprite you want to change.")]
    [SerializeField]
    private Image spriteField;

    [SerializeField]
    private Sprite spriteOne;

    [SerializeField]
    private Sprite SpriteTwo;

    private void Start()
    {
        spriteField.sprite = spriteOne;
    }

    public void LoadSpriteTwo()
    {
        spriteField.sprite = SpriteTwo;
    }

    public void LoadSpriteOne()
    {
        spriteField.sprite = spriteOne;
    }
}
