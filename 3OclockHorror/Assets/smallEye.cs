using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smallEye : MonoBehaviour
{
    float rate;
    Image myImg;
    // Start is called before the first frame update
    void Start()
    {
        rate = Random.Range(2, 6);
        myImg = this.GetComponent<Image>();
        myImg.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        float a = myImg.color.a;
        if (a > 0)
        {
            a -= Time.deltaTime / rate;
            myImg.color = new Color(255, 255, 255, a);
        }
    }
}
