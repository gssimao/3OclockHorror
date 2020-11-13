using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoController : MonoBehaviour
{
    [SerializeField]
    List<Item> Photos;
    [SerializeField]
    List<Inventory> AllowedInvs;
    [Space]
    [SerializeField]
    Inventory DiningRoom;
    
    List<string> Dates;
    List<string> Numerals;

    public bool Distributed;

    // Start is called before the first frame update
    void Start()
    {
        if(Photos == null || AllowedInvs == null)
        {
            Debug.LogError("One or more of the necessary items for photo puzzle initiation is not set.");
        }
        else if(AllowedInvs.Count < Photos.Count)
        {
            Debug.LogError("Allowed invs must contain at least as many inventories as photos contains photos");
        }

        InitPuzzle();
        Distributed = false;
    }

    public void DistPhotos() //Called once to distribute photos. Only occurs when the first photo is grabbed
    {
        /*
        foreach(Item photo in Photos)
        {
            int rand = Random.Range(0, AllowedInvs.Count);
            Inventory selectedInv = AllowedInvs[rand];

            selectedInv.AddStartingItem(photo);
            AllowedInvs.Remove(selectedInv);

            Debug.Log("Selected Inv: " + selectedInv.gameObject.name);

            if (AllowedInvs.Contains(selectedInv))
            {
                Debug.Log("Something went wacky there - PhotoController");
            }
        }
        */

        for(int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, Photos.Count);
            Item photo = Photos[rand];
            rand = Random.Range(0, AllowedInvs.Count);
            Inventory selectedInv = AllowedInvs[rand];

            selectedInv.AddStartingItem(photo);
            AllowedInvs.Remove(selectedInv);
            Photos.Remove(photo);

            Debug.Log("Selected Inv: " + selectedInv.gameObject.name);

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
    }
}
