using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OpenDexPage : MonoBehaviour
{
    public void OnDexButtonPressed()
    {
        if (transform.lossyScale != Vector3.zero)
        {
            transform.DOScale(Vector3.zero, 0.5f);
        }
        else
        {
            transform.DOScale(Vector3.one, 0.5f);
        }
    }
}
