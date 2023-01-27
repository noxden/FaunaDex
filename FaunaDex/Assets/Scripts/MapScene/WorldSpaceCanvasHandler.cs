//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 27-01-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceCanvasHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
