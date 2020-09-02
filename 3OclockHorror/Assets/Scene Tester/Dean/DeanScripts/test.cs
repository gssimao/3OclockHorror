using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
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
        Debug.Log("trigger");
        if(other.gameObject.tag == "Pillar3")
        {
            Debug.Log("Pillar3 good");
        }
        if(other.gameObject.tag == "Pillar1")
        {
            Debug.Log("Pillar1 good");
        }
        if(other.gameObject.tag == "Pillar2")
        {
            Debug.Log("Pillar2 good");
        }
        if(other.gameObject.tag == "Pillar4")
        {
            Debug.Log("Pillar4 good");
        }    
    }
}
