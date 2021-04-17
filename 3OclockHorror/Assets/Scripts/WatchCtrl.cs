using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchCtrl : MonoBehaviour
{
    [SerializeField]
    public clockCntrl Clock;
    [SerializeField]
    GameObject invCanv;
    public Inventory inv;
    public Inventory workbench;
    public Item Gear1;
    public Item Gear2;
    public Item Gear3;
    public AnswerCheckPocketWatch pwcheck;
    public bool solved;
    public bool disabled;
    // Start is called before the first frame update
    void Start()
    {
        disabled = false;
        solved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Clock.Clock >= 1680 && Clock.Clock <= 1682 && !solved && !disabled)
        {
            invCanv.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
            disabled = true;
            int c = inv.Count();
            Debug.Log("c = " + c);
            if (c < 3)
            {
                inv.AddItem(Gear1);
                inv.AddItem(Gear2);
                inv.AddItem(Gear3);
                Debug.Log("Items added to player");
            }
            else
            {
                workbench.AddStartingItem(Gear1);
                workbench.AddStartingItem(Gear2);
                workbench.AddStartingItem(Gear3);
                Debug.Log("Items added to workbench");
            }
            invCanv.SetActive(false);
        }
        if (Clock.Clock > 1680 && pwcheck.solved == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            solved = true;
            disabled = false;
        }
    }
}
