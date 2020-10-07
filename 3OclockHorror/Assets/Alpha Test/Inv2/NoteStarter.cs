using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteStarter : MonoBehaviour
{
    [SerializeField]
    Item Note1;
    // Start is called before the first frame update
    void Start()
    {
        if (Note1.Note)
        {
            Note1.SetContainers();
        }
    }
}
