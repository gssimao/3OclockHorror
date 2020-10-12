using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteStarter : MonoBehaviour
{
    [SerializeField]
    List<Item> Notes;

    List<Inventory> CntInvs;
    // Start is called before the first frame update
    void Start()
    {
        FindAllContainers();

        foreach(Item Note in Notes)
        {
            int rand = Random.Range(0, CntInvs.Count - 1);
            while(rand < 0)
            {
                rand = Random.Range(0, CntInvs.Count - 1);
            }
            Note.myInv = CntInvs[rand];
            CntInvs.Remove(Note.myInv);
        }
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
            Debug.Log("Cnt " + cnt.name + " added");
        }
    }
}
