using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPuzzle : MonoBehaviour
{
    public bool openWithNoPhotos = true; // this will determine if we open the puzzle with a photo in our inventory or not
    public int photoFoundCount = 0;
    [SerializeField]
    Inventory plyInv;
    [SerializeField]
    GameObject invCanv;
    [SerializeField]
    List<LPhotoCntrl> photos;
    [SerializeField]
    GameObject puzzleGO;
    [SerializeField]
    PicSlot[] Slots;

    float dist;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < photos.Count; i++)
        {
            photos[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleGO.activeSelf)
        {
            for (int i = 0; i < photos.Count; i++)
            {
                if (!plyInv.ContainsItem(photos[i].myPhoto) || photos[i].myPhoto == null)
                {
                    photos[i].gameObject.SetActive(false);
                }
                else
                {
                    invCanv.SetActive(true);
                    photoFoundCount++;
                    photos[i].gameObject.SetActive(true);
                    plyInv.RemoveItem(photos[i].myPhoto);
                    openWithNoPhotos = false;
                    GameObject photoPuzzle = GameObject.Find("Photo Frame");
                    photoPuzzle.GetComponent<PuzzleOpenerScript>().havePhoto = true;
                    if(photoFoundCount == 4)
                    {
                        photoPuzzle.GetComponent<PuzzleOpenerScript>().allPhotoFounds = true;
                    }
                    //Debug.Log("Item: " + photos[i].myPhoto.ItemName + " at index: " + i + " has been removed");
                    photos.RemoveAt(i);

                    invCanv.SetActive(false);
                }
            }
        }
    }
}
