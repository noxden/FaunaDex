using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    public static PersistentData instance { set; get; }

    public Texture2D photoDragonfly;
    public Texture2D photoOtter;

    //# Monobehaviour Events 
    private void Awake()
    {
        //# Singleton Setup 
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        // Sprite.Create(photoDragonfly, new Rect(0, 0, photoDragonfly.width, photoDragonfly.height));
    }
}
