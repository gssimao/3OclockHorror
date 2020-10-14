using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteStarter : MonoBehaviour
{
    [SerializeField]
    List<Item> Notes;
    [SerializeField]
    Inventory StarterInv;
    [SerializeField]
    Item FirstNote;
    [SerializeField]
    Item LastNote;
    [SerializeField]
    Item key;

    List<Inventory> CntInvs;
    // Start is called before the first frame update
    void Start()
    {
        FindAllContainers();

        foreach(Item Note in Notes)
        {
            int rand = Random.Range(0, CntInvs.Count);
            while(rand < 0)
            {
                rand = Random.Range(0, CntInvs.Count);
            }
            Note.myInv = CntInvs[rand];
            Note.desc = "A note in a series of notes";
            Note.isRead = false;
            CntInvs.Remove(Note.myInv);
        }

        FirstNote.myInv = StarterInv;
        FirstNote.isRead = false;
        FirstNote.desc = "A note in a series of notes.";
        FirstNote.myInv.AddStartingItem(FirstNote);

        LastNote.myInv = StarterInv;
        LastNote.isRead = false;
        LastNote.desc = "A note in a series of notes.";

        key.myInv = LastNote.myInv;
    }

    void FindAllContainers()
    {

        GameObject[] NoteContainers = GameObject.FindGameObjectsWithTag("NoteContainer");
        CntInvs = new List<Inventory>();

        foreach (GameObject cnt in NoteContainers)
        {
            CntInvs.Add(cnt.GetComponent<Inventory>());
        }

        if (CntInvs.Contains(StarterInv))
        {
            CntInvs.Remove(StarterInv);
        }
    }
}
