//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 06-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerHelper : MonoBehaviour
{
    public void SetLayerToRaycastTarget()
    {
        this.gameObject.layer = LayerMask.NameToLayer("RaycastTarget");
    }
}
