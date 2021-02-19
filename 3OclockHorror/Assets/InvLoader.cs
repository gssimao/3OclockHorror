using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvLoader : MonoBehaviour
{
    [SerializeField]
    GameObject InvCanv;
    [SerializeField]
    GameObject CntCanv;

    // Start is called before the first frame update
    void Start()
    {
        var cnts = FindObjectsOfType<ContainerControl>();

        if(cnts != null) 
        {

            foreach (ContainerControl cnt in cnts)
            {
                InvCanv.SetActive(true);
                CntCanv.SetActive(true);

                cnt.openInventory();
                Debug.Log("Cnt: " + cnt.gameObject.name);

                InvCanv.SetActive(true);
                CntCanv.SetActive(true);
                cnt.closeInventory();
            }
        }

        if (InvCanv.activeSelf)
        {
            InvCanv.SetActive(false);
        }
        CntCanv.SetActive(false);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
