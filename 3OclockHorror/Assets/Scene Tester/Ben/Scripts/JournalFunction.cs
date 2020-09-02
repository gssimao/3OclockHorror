using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalFunction : MonoBehaviour
{
    public GameObject jounralUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            SetJounralToggle();
        }
    }
    public void SetJounralToggle()
    {
        if(jounralUI.activeSelf)
        {
            jounralUI.SetActive(false);
        }
        else
        {
            jounralUI.SetActive(true);
        }
    }
}
