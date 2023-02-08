//================================================================
// Darmstadt University of Applied Sciences, Expanded Realities
// Course:       Project 5 (Grimm, Hausmeier, Vollert)
// Script by:    Daniel Heilmann (771144)
// Last changed: 06-02-23
//================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canTalk = true;

    private void Update()
    {
        if (!canTalk)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            OnScreenTap(touch.position);
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))    //< Simulate screen tap
        {
            OnScreenTap(Input.mousePosition);
        }
#endif
    }

    public void OnScreenTap(Vector2 screenPosition)
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red, 10f);

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.Log($"PlayerController: Raycast hit {hitInfo.collider.name}.", this);
            if (hitInfo.collider.tag == "DialogueAnimal")
            {
                Debug.Log($"PlayerController: It's a DialogueAnimal!", this);
                // hitInfo.collider.GetComponentInParent<DialogueLink>()?.linkedDisplayHelper.Display();
                FindObjectOfType<DialogueDisplayHelper>().Display();
            }
        }
    }
}
