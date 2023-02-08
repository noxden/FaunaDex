using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWelcomeScreen : MonoBehaviour
{
    public static bool hasBeenRead = false;

    public void CloseWelcome()
    {
        gameObject.SetActive(false);
        hasBeenRead = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(!hasBeenRead);
    }
}
