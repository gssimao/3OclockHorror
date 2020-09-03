using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public float sanityValue; //Variable that holds how much sanity the player has

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void ChangeSanity(float changeValue)
    {
        sanityValue = sanityValue + changeValue;
    }
}
