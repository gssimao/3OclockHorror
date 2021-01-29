using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPuzzle : MonoBehaviour
{
    [SerializeField]
    Inventory plyInv;
    [SerializeField]
    LPhotoCntrl[] photos;
    [SerializeField]
    GameObject puzzleGO;
    [SerializeField]
    PicSlot[] Slots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleGO.activeSelf)
        {
            for (int i = 0; i < photos.Length; i++)
            {
                if (plyInv.ContainsItem(photos[i].myPhoto))
                {
                    if (photos[i].me != null)
                    {
                        photos[i].me.enabled = true;
                    }
                }
                else
                {
                    if (photos[i].me != null)
                    {
                        photos[i].me.enabled = false;
                    }
                }
            }
        }
    }
}
