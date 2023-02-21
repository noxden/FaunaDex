using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DexEntryHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> DexImages;

    private int Index { get; set; } = 0;
    private GameObject MapArea => GameObject.Find("MapArea");
    private Image DexImage => GameObject.Find("DexImages").GetComponent<Image>();

    public void NextImage()
    {
        if (Index < DexImages.Count)
        {
            Index += 1;
        }

        if (Index == DexImages.Count)
        {
            Index = 0;
        }

        DexImage.sprite = DexImages[Index];
    }

    public void PreviousImage()
    {
        if (Index > 0)
        {
            Index -= 1;
        }

        else if (Index == 0)
        {
            Index = DexImages.Count-1;
        }
        DexImage.sprite = DexImages[Index];
    }

    public void OpenMap()
    {
        MapArea.transform.DOScaleY(1, 1);
    }

    public void CloseMap()
    {
        MapArea.transform.DOScaleY(0, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        DexImage.sprite = DexImages[Index];
    }
}
