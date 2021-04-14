using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invInitOpener : MonoBehaviour
{
    [SerializeField]
    workbench_cntrl benchToOpen;
    bool opened = false;
    bool closed = false;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup > 0f && !opened)
        {
            startTime = Time.realtimeSinceStartup;
            benchToOpen.open();
            opened = true;
        }
        else if(Time.realtimeSinceStartup > startTime && opened && !closed)
        {
            benchToOpen.close();
            closed = true;
        }
        else if(opened && closed)
        {
            Destroy(this.gameObject);
        }
    }
}
