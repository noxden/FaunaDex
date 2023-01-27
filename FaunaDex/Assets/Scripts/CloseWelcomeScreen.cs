using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWelcomeScreen : MonoBehaviour
{
    public GameObject WelcomeScreen;

    public void CloseWelcome()
    {
        WelcomeScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
