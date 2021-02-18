using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareCtrl : MonoBehaviour
{
    float x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            x += Time.deltaTime;
            if (x > 3)
            {
                x = 0;
                this.gameObject.SetActive(false);
            }
        }
    }
}
