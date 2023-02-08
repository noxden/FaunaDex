using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CloseWelcomeScreen : MonoBehaviour
{
    public static bool hasBeenRead = false;

    public void CloseWelcome()
    {
        
        transform.DOScale(Vector3.zero, 0.2f);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(!hasBeenRead);
    }
}
