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
