using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invBlinkController : MonoBehaviour
{
    [SerializeField]
    Inventory parentInv;
    [SerializeField]
    SpriteRenderer sr;

    void Start()
    {
        parentInv = this.gameObject.transform.parent.GetComponent<Inventory>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        if(parentInv == null || sr == null)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(parentInv.countArrayItems() == 0)
        {
            sr.enabled = false;
        }
        else
        {
            sr.enabled = true;
        }
    }
}
