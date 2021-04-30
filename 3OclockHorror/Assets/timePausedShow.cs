using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePausedShow : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    bool on;

    private void Update()
    {
        if(!on && Time.timeScale == 0)
        {
            obj.SetActive(true);
            on = true;
        }
        else if(on && Time.timeScale != 0)
        {
            obj.SetActive(false);
            on = false;
        }
    }
}
