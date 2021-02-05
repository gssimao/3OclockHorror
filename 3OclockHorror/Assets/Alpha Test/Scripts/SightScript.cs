using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightScript : MonoBehaviour
{
    public Light candle;
    public Light playerMatch;

    public GameObject[] Furniture;
    // Start is called before the first frame update
    void Start()
    {
        Furniture = GameObject.FindGameObjectsWithTag("Furniture");
    }

    // Update is called once per frame
    void Update()
    {
        Furniture = GameObject.FindGameObjectsWithTag("Furniture");

        if (!candle.isActiveAndEnabled)
        {
            if (Vector3.Distance(this.transform.position, playerMatch.transform.position) <= candle.range && playerMatch.isActiveAndEnabled)
            {

            }
            else
            {
                for (int i = 0; i < Furniture.Length; i++)
                {
                    if (Vector3.Distance(this.transform.position, Furniture[i].transform.position) <= candle.range)
                    {
                        Furniture[i].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < Furniture.Length; i++)
            {
                if (Vector3.Distance(this.transform.position, Furniture[i].transform.position) <= candle.range)
                {
                    Furniture[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
        if(Vector3.Distance(this.transform.position, playerMatch.transform.position) <= candle.range && playerMatch.isActiveAndEnabled)
        {

        }
    }
}
