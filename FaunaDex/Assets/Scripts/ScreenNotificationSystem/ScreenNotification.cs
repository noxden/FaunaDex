//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 08-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenNotification : MonoBehaviour
{
    private string _contentText;
    public string contentText
    {
        get
        {
            return _contentText;
        }
        set
        {
            if (contentField != null)
            {
                _contentText = value;
                contentField.text = _contentText;
            }
        }
    }

    private string _buttonText;

    public string buttonText
    {
        get
        {
            return buttonText;
        }
        set
        {
            if (buttonField != null)
            {
                buttonText = value;
                contentField.text = buttonText;
            }
        }
    }

    [SerializeField]
    [Tooltip("You may assign this to a text field of your choice. Otherwise, it's set automatically to the first TextMeshProUGUI component.")]
    private TextMeshProUGUI contentField;

    [SerializeField]
    [Tooltip("You may assign this to a text field of your choice. Otherwise, it's set automatically to a TextMeshProUGUI component that is a child of the button.")]
    private TextMeshProUGUI buttonField;

    [SerializeField]
    [Tooltip("You may assign this to a text field of your choice. Otherwise, it's set automatically to the first Button component or the button that buttonField is a child of.")]
    private Button button;

    [Space(10)]
    [Header("Events Section")]
    [Space(5)]
    public UnityEvent OnButtonClicked;

    public void Setup() //> Would be called too late if it was in Start() as it would have been bound to the Unity Lifecycle
    {
        if (contentField == null)
            contentField = GetComponentInChildren<TextMeshProUGUI>();

        if (buttonField != null)
            button = buttonField.GetComponentInParent<Button>();

        if (button == null)
        {
            button = GetComponentInChildren<Button>();
            buttonField = button.GetComponentInChildren<TextMeshProUGUI>();
        }

        // if (button != null)
        //     button.onClick.AddListener(ButtonClickRelay);
    }

    public void Close()
    {
        ScreenNotificationHandler.Close(this);
    }

    /// <summary>
    /// Only public for hooking into the button event of ScreenNotification in the prefabs via editor.
    /// </summary>
    public void ButtonClickRelay()
    {
        OnButtonClicked?.Invoke();
    }
}
