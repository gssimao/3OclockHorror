using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workbench_cntrl : MonoBehaviour
{
    public GameObject player;
    public GameObject timeUI; //Time UI, used to deactivate for screenclutter.
    public GameObject myWorkspace; //The canvas for this specific workbench to work with.
    public GameObject ePrompt; //Prompt to press E - can be changed.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist <= 1.5f)
        {
            ePrompt.SetActive(true);

            if (Input.GetKeyDown("e"))
            {
                timeUI.SetActive(false);
                myWorkspace.SetActive(true);
            }
        }
        else
        {
            ePrompt.SetActive(false);
        }
    }
}
