using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    GameObject didwin;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        didwin = GameObject.FindGameObjectWithTag("Check");
        test Test = didwin.GetComponent<test>();
        Test.didYaWin = true;
        if (Test.didYaWin == true)
        {
            gameObject.SetActive(true);
        }
    }
}
