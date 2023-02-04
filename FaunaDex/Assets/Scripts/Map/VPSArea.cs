//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 29-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSArea : MonoBehaviour
{
    public Scene linkedScene;

    [SerializeField]
    private bool startHidden;

    // [Tooltip("Only for visualization, do not touch!")]
    // [SerializeField]
    private List<GameObject> children;

    private void Start()
    {
        children = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            children.Add(child);
        }

        if (startHidden)
            Hide();
    }

    public void Hide()
    {
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
    }

    public void Show()
    {
        foreach (GameObject child in children)
        {
            child.SetActive(true);
        }
    }
}
