//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 29-01-23
//================================================================

using UnityEngine;
using UnityEngine.UI;

public class MenuButtonHelper : MonoBehaviour
{
    private Button button;  //< Automatically assigns a button from the GameObject this script is on.
    
    [SerializeField]
    private Sprite activatedButtonSprite;

    [SerializeField]
    private Sprite deactivatedButtonSprite;

    private void Start()
    {
        button = GetComponent<Button>();
        //button.colors.disabledColor = button.colors.normalColor;
    }

    public void ActivateButton()
    {
        button.interactable = true;
        button.image.sprite = activatedButtonSprite;
    }

    public void DeactivateButton()
    {
        button.interactable = false;
        button.image.sprite = deactivatedButtonSprite;
    }
}
