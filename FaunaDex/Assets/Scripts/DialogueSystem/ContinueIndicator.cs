using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueIndicator : MonoBehaviour
{
    private Image image;

    [SerializeField]
    private bool startHidden;

    private void Start()
    {
        image = GetComponent<Image>();

        if (startHidden)
            Hide();
    }

    public void Hide()
    {
        image.enabled = false;
    }

    public void Show()
    {
        image.enabled = true;
    }
}
