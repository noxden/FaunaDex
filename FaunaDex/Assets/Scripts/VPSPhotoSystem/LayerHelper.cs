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
        //> Set layer for owner
        this.gameObject.layer = LayerMask.NameToLayer("RaycastTarget");

        //> Set layer for all children of owner
        List<GameObject> children = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            children.Add(child);
        }

        children.RemoveAll(x => x.TryGetComponent<DialogueBubble>(out _) == true);

        foreach (GameObject child in children)
        {
            child.layer = LayerMask.NameToLayer("RaycastTarget");
        }

    }
}
