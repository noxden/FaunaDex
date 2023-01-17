using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private GameObject settingsButton;

    private bool isShowing { get; set; } = false;
    
    public void ToggleSettingsMenu()
    {
        switch (isShowing)
        {
            case false:
            {
                settingsButton.SetActive(false);
                buttons.SetActive(true);
                isShowing = true;
                return;
            }
            case true:
            {
                settingsButton.SetActive(true);
                buttons.SetActive(false);
                isShowing = false;
                break;
            }
        }
    }
}
