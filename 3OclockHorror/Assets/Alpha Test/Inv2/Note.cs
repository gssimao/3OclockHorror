using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Note", order = 3)]
public class Note : Item
{
    public string text = "The room I am in is ***."; //Any text for the player
    [SerializeField]
    List<Inventory> Containers;
    [SerializeField]
    Note nextNote;

    public void Start()
    {
        if(Containers == null)
        {
            Debug.LogError("Hey Asshole you're fuckin stupid, gimme some containers");
        }
    }

    public void SetNextNote()
    {
        int indx = Random.Range(0, Containers.Count); //Generate an index for the room

        string room = Containers[indx].gameObject.GetComponentInParent<room>().getName();
        Containers[indx].AddItem(nextNote);

        text = text.Replace("***", room); //Replace the *** with the room that was selected
    }
}
