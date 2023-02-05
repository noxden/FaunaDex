using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DexEntriesHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> DexSprites;
    
    private List<GameObject> DexEntries { get; set; }

    private int QuestStage => PersistentQuestData.instance.questStage_Otto;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Sprite entry in DexSprites)
        {
            GameObject go = Instantiate(
                new GameObject("DexEntry" + entry.name, typeof(RectTransform),typeof(Image), typeof(Button)),
                transform);
            go.GetComponent<Image>().sprite = entry;
            Rect rect = go.GetComponent<RectTransform>().rect;
            rect.width = entry.rect.width;
            rect.height = entry.rect.height;
            go.GetComponent<Button>().enabled = false;
            //DexEntries.Add(go);
        }

        if (DexEntries != null)
        {
            for (int i = 0; i <= QuestStage; i+=2)
            {
                DexEntries[i].GetComponent<Button>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
