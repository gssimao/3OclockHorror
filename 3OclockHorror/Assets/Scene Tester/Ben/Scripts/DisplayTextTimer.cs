using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextTimer : MonoBehaviour
{
    public Text textBox;
    public float timer;

    float ov;
    // Start is called before the first frame update
    void Start()
    {
        ov = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (textBox.text != "")
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            textBox.text = "";
            timer = ov;
        }
    }
}
