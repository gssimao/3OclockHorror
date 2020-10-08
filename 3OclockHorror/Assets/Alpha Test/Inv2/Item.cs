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


    public void SetNextNote()
    {
        if (nextNote != null)
        {
            int indx = Random.Range(0, Containers.Count - 1); //Generate an index for the room

            string room = Containers[indx].gameObject.GetComponentInParent<room>().getName(); //Get the room name
            Containers[indx].AddItem(nextNote); //Add the item to the inventory
            Containers.RemoveAt(indx); //Remove the container
            nextNote.PassContainers(Containers); //Pass along the list for the next item;

            text = text.Replace("***", room); //Replace the *** with the room that was selected
        }
    }

    public void PassContainers(List<Inventory> Containers)
    {
        this.Containers = Containers;
    }

    public void SetContainers()
    {
        Containers.Clear();
        GameObject[] cnts = GameObject.FindGameObjectsWithTag("Container");
        foreach (GameObject obj in cnts)
        {
            Containers.Add(obj.GetComponent<Inventory>());
        }
    }

    #endregion
}
