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
    Item Note1;
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

        Note1.myInv = StarterInv;
        Note1.isRead = false;
        Note1.desc = "A note in a series of notes.";

        key.myInv = Note1.myInv;
    }
    void Update()
    {
        
    }

    void FindAllContainers()
    {

        GameObject[] NoteContainers = GameObject.FindGameObjectsWithTag("NoteContainer");
        CntInvs = new List<Inventory>();

        foreach (GameObject cnt in NoteContainers)
        {
            CntInvs.Add(cnt.GetComponent<Inventory>());
            Debug.Log("Cnt : " + cnt.name + " : added");
        }
    }
}
