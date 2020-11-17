using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoController : MonoBehaviour
{
    [SerializeField]
    List<Item> Photos;
    [SerializeField]
    List<Inventory> AllowedInvs;
    [SerializeField]
    List<LPhotoCntrl> LPhotos;
    [Space]
    [SerializeField]
    Inventory DiningRoom;
    
    List<string> Dates = new List<string> {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
    List<string> Numerals;

    public bool Distributed;

    // Start is called before the first frame update
    void Start()
    {
        if(Photos == null || AllowedInvs == null)
        {
            Debug.LogError("One or more of the necessary items for photo puzzle initiation is not set.");
        }
        else if(AllowedInvs.Count < 3)
        {
            Debug.LogError("Allowed invs must contain at least as many inventories as photos contains photos");
        }

        if(LPhotos.Count != 4)
        {
            Debug.LogError("Need 4 LPhotos");
        }

        InitPuzzle();
        Distributed = false;
    }

    public void DistPhotos() //Called once to distribute photos. Only occurs when the first photo is grabbed
    {
        for(int i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, Photos.Count);
            Item photo = Photos[rand];
            rand = Random.Range(0, AllowedInvs.Count);
            Inventory selectedInv = AllowedInvs[rand];

            selectedInv.AddStartingItem(photo);
            AllowedInvs.Remove(selectedInv);
            Photos.Remove(photo);

            rand = Random.Range(0, Dates.Count);
            photo.numeral = Dates[rand];
            Dates.RemoveAt(rand);

            LPhotos[i + 1].InitLargePhoto(photo);

            if (AllowedInvs.Contains(selectedInv))
            {
                Debug.Log("Something went wacky there - PhotoController");
            }
        }

        Distributed = true;
    }

    public void InitPuzzle()
    {
        int rand = Random.Range(0, Photos.Count);
        Item photo = Photos[rand];
        DiningRoom.AddStartingItem(photo);
        Photos.Remove(photo);

        rand = Random.Range(0, Dates.Count);
        photo.numeral = Dates[rand];
        Dates.RemoveAt(rand);

        LPhotos[0].InitLargePhoto(photo);
    }
}
