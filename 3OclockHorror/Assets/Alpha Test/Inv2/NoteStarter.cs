using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteStarter : MonoBehaviour
{
    [SerializeField]
    Item FirstNote;
    [Space]
    [SerializeField]
    List<Item> Notes;
    [Space]
    [SerializeField]
    Item LastNote;
    [Space]
    [SerializeField]
    Inventory StarterInv;
    [SerializeField]
    Inventory FinalInv;
    [SerializeField]
    Item key;
    [SerializeField]
    Item amulet;

    List<Inventory> CntInvs;
    List<Inventory> RandInvs = new List<Inventory>();
    int InvPos = 0; //Current inventory position.
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void initNotePuzzle()
    {
        FindAllContainers();
        RandInvs.Clear();

        FirstNote.myInv = StarterInv;
        FirstNote.isRead = false;
        FirstNote.desc = "A note in a series of notes.";
        FirstNote.myInv.AddStartingItem(FirstNote);

        foreach (Item Note in Notes)
        {
            int rand = Random.Range(0, CntInvs.Count - 1);
            while (rand < 0 || rand == CntInvs.Count)
            {
                rand = Random.Range(0, CntInvs.Count - 1);
            }
            RandInvs.Add(CntInvs[rand]);
            CntInvs.RemoveAt(rand);

            Note.desc = "A note in a series of notes";
            Note.isRead = false;
        }

        LastNote.myInv = FinalInv;
        LastNote.isRead = false;
        LastNote.desc = "A note in a series of notes.";

        key.myInv = FinalInv;
        amulet.myInv = FinalInv;
    }

    public void SetNextNoteInventory(Item note)
    {
        if (note.nextNote != null && note.nextNote != LastNote && InvPos < RandInvs.Count) 
        {
            note.nextNote.myInv = RandInvs[InvPos];
        }
        if(note.nextNote != LastNote && note.nextNote.myInv == FinalInv)
        {
            Debug.LogError("Note that is not last note is getting sent to final inventory");
        }
        note.NextNoteInit();
        InvPos++;
    }

    public void CheckInvs(List<Inventory> list)
    {
        foreach(Inventory inv in list)
        {
            Debug.Log("Name: " + inv.name);
        }
    }
}
