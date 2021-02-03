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
            photos[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < photos.Length; i++)
        {
            if (!plyInv.ContainsItem(photos[i].myPhoto) || photos[i].myPhoto == null)
            {
                photos[i].gameObject.SetActive(false);
            }
            else if (myInv.ContainsItem(photos[i].myPhoto))
            {
                photos[i].gameObject.SetActive(true);
            }
            else
            {
                photos[i].gameObject.SetActive(true);
            }
        }
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].photoinSlot != null)
            {
                Item photo = Slots[i].photoinSlot.myPhoto;

                if (photo != null)
                {
                    plyInv.RemoveItem(photo);

                    myInv.AddItem(photo);
                    Debug.Log(photo.ItemName + " has been added to the inventory");
                }
            }
        }
    }
}
