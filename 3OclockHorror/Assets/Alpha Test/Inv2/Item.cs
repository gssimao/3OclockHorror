using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items", order = 1)]
public class Item : ScriptableObject
{
    //Name, icon, and descriptions
    public string ItemName; //Name of the Item
    public Sprite Icon; //The Item Icon
    public string desc; //A description of what the item is

    //Location Variables
    public bool rand;

    //Some specific stuff for different types of items
    #region Note
    public bool Note;
    public string text;
    [SerializeField]
    List<Inventory> Containers;
    [SerializeField]
    Item nextNote;
    [SerializeField]
    Item Key;

    Inventory lib;

    public void SetNextNote()
    {
        if (nextNote != null) //I am not the last note
        {
            int indx = Random.Range(0, Containers.Count); //Generate an index for the room

            string room = Containers[indx].gameObject.GetComponentInParent<room>().getName(); //Get the room name
            Containers[indx].OpenInv();
            Containers[indx].AddItem(nextNote); //Add the item to the inventory
            Containers[indx].CloseInv();
            Containers.RemoveAt(indx); //Remove the container
            nextNote.PassContainers(Containers, lib, Key); //Pass along the list for the next item;

            text = text.Replace("***", room); //Replace the *** with the room that was selected
        }
        if(nextNote == null) //I am the last note
        {
            text = text.Replace("***", "Library");
            lib.OpenInv();
            lib.AddItem(Key);
            lib.CloseInv();
        }
    }

    public void PassContainers(List<Inventory> Containers, Inventory Lib, Item key)
    {
        this.Containers = Containers;
        this.lib = Lib;
        this.Key = key;
    }

    public void SetContainers(Inventory Lib)
    {
        Containers.Clear();
        GameObject[] cnts = GameObject.FindGameObjectsWithTag("NoteContainer");
        foreach (GameObject obj in cnts)
        {
            Containers.Add(obj.GetComponent<Inventory>());
        }
        lib = Lib;
    }

    #endregion
}
