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

    int dateSelector;
    List<string> SelectedDate;

    List<string> Dates1 = new List<string> { "1896", "1897", "1899", "1903" };
    List<string> Dates2 = new List<string> { "1892", "1894", "1899", "1900" };
    List<string> Dates3 = new List<string> { "1891", "1898", "1905", "1907" };
    List<string> Numerals = new List<string> { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };

    public bool Distributed;

    [SerializeField]
    Padlock padlock;
    [SerializeField]
    CraftingRecipe photoRecipie;
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

        dateSelector = Random.Range(0, 3);

        if(dateSelector == 0)
        {
            SelectedDate = Dates1;
        }
        else if(dateSelector == 1)
        {
            SelectedDate = Dates2;
        }
        else
        {
            SelectedDate = Dates3;
        }

        photoRecipie.Pieces.Clear();
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

            rand = Random.Range(0, Numerals.Count);
            photo.numeral = Numerals[rand];
            Numerals.RemoveAt(rand);

            photo.date = SelectedDate[i + 1];

            LPhotos[i + 1].InitLargePhoto(photo);

            if (AllowedInvs.Contains(selectedInv))
            {
                Debug.Log("Something went wacky there - PhotoController");
            }

            if(i == 0)
            {
                padlock.Photo2 = photo;
            }
            else if(i == 1)
            {
                padlock.Photo3 = photo;
            }
            else if(i == 2)
            {
                padlock.Photo4 = photo;
            }

            photoRecipie.Pieces.Add(photo);
        }

        Distributed = true;
    }

    public void InitPuzzle()
    {
        int rand = Random.Range(0, Photos.Count);
        Item photo = Photos[rand];
        DiningRoom.AddStartingItem(photo);
        Photos.Remove(photo);

        padlock.Photo1 = photo;
        photoRecipie.Pieces.Add(photo);

        rand = Random.Range(0, Numerals.Count);
        photo.numeral = Numerals[rand];
        Numerals.RemoveAt(rand);
        photo.date = SelectedDate[0];

        LPhotos[0].InitLargePhoto(photo);
    }
}
