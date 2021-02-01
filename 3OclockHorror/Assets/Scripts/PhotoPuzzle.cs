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
    [SerializeField]
    Inventory myInv;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < photos.Length; i++)
        {
            photos[i].me.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleGO.activeSelf)
        {
            for (int i = 0; i < photos.Length; i++)
            {
                if (!plyInv.ContainsItem(photos[i].myPhoto) || photos[i].myPhoto == null)
                {
                    if (myInv.ContainsItem(photos[i].myPhoto))
                    {
                        photos[i].me.enabled = true;
                    }
                    else
                    {
                        photos[i].me.enabled = false;
                    }
                }
                else
                {
                    if (photos[i].me != null)
                    {
                        photos[i].me.enabled = true;
                    }
                }
            }
        }
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].photoinSlot != null)
            {
                Item photo = Slots[i].photoinSlot.GetComponent<LPhotoCntrl>().myPhoto;

                if (photo != null)
                {
                    plyInv.RemoveItem(photo);

                    myInv.AddItem(photo);
                }
            }
        }
    }
}
