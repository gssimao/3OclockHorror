using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    GameObject[] Traps;
    float clocktime;
    clockCntrl Clockctrl;
    public float wait;
    public int triggered;
    bool active;
    bool full;

    // Start is called before the first frame update
    void Start()
    {
        Clockctrl = gameObject.GetComponent<clockCntrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!active)
        {
            ActivateTraps();
            wait = 0f;
            active = true;
        }
        if (active)
        {
            wait += Time.deltaTime;
            if(wait > 120 && wait < 122)
            {
                int total = 0;
                full = true;
                foreach (GameObject Trap in Traps)
                {
                    if (!Trap.activeSelf) 
                    {
                        total++;
                    } //Checks to make sure not all traps are active
                }
                if(total < Traps.Length)
                {
                    full = false;
                }
                if (!full)
                {
                    ActivateTraps();
                    wait = 0f;
                }
            }
        }
    }

    private void Awake()
    {
        Traps = GameObject.FindGameObjectsWithTag("Beartrap");
        foreach (GameObject Trap in Traps)
        {
            Trap.SetActive(false);
        }
        GameObject.Find("TrapControl").SetActive(false);
    }

    private void ActivateTraps()
    {
        int total = 0;

        foreach(GameObject Trap in Traps)
        {
            Trap.SetActive(true);

            total++;
        }
    }

    public void DeactivateTraps()
    {
        foreach (GameObject Trap in Traps)
        {
            Trap.SetActive(false);
        }
        wait = 0f;
    }
}
