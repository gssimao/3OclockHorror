using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private bool pillar1 = false;
    private bool pillar2 = false;
    private bool pillar3 = false;
    private bool pillar4 = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pillar3")
        {
            Debug.Log("Pillar3 good");
            pillar3 = true;
        }
        if(other.gameObject.tag == "Pillar1")
        {
            Debug.Log("Pillar1 good");
            pillar1 = true;
        }
        if(other.gameObject.tag == "Pillar2")
        {
            Debug.Log("Pillar2 good");
            pillar2 = true;
        }
        if(other.gameObject.tag == "Pillar4")
        {
            Debug.Log("Pillar4 good");
            pillar4 = true;
        }

        if(pillar1 == true && pillar2 == true && pillar3 == true && pillar4 == true)
        {
            Debug.Log("Puzzle solved");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pillar3")
        {
            pillar3 = true;
        }
        if (other.gameObject.tag == "Pillar1")
        {
            pillar1 = true;
        }
        if (other.gameObject.tag == "Pillar2")
        {
            pillar2 = true;
        }
        if (other.gameObject.tag == "Pillar4")
        {
            pillar4 = true;
        }
    }
}
