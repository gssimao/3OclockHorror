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
                full = true;
                foreach (GameObject Trap in Traps)
                {
                    if (!Trap.activeSelf) { full = false; } //Checks to make sure not all traps are active
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
    }

    private void ActivateTraps()
    {
        for (int i = 0; i < 3; i++)
        {
            int rand = Mathf.RoundToInt(Random.Range(0, Traps.Length));
            while (Traps[rand].activeSelf)
            {
                rand = Mathf.RoundToInt(Random.Range(0, Traps.Length));
            }
            Traps[rand].SetActive(true);
            Debug.Log("Trap " + Traps[rand].name + " Activated");
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
