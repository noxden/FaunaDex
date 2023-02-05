using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CloseWelcomeScreen : MonoBehaviour
{

    public void CloseWelcome()
    {
        
        transform.DOScale(Vector3.zero, 0.2f);
        
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
