using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinEnding : MonoBehaviour
{
    [SerializeField]
    GameObject chest1;
    [SerializeField]
    GameObject chest2;
    [SerializeField]
    GameObject ladder;

    float time;
    float c1time;
    float c2time;
    float ldrtime;

    Image c1;
    Image c2;
    Image ldr;

    [SerializeField]
    GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        c1 = chest1.GetComponent<Image>();
        c2 = chest2.GetComponent<Image>();
        ldr = ladder.GetComponent<Image>();


        time = Time.realtimeSinceStartup;
        c1time = time + 1;
        c2time = time + 2.5f;
        ldrtime = time + 4;
        chest1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup < c1time)
        {
            chest1.SetActive(true);
        }
        else if(Time.realtimeSinceStartup > c1time && Time.realtimeSinceStartup < c2time)
        {
            if(c1.color.a > 0)
            {
                Color newColor = c1.color;
                float newA = c1.color.a;
                newA -= (2 * Time.deltaTime);
                newColor.a = newA;
                c1.color = newColor;
            }
            else
            {
                chest1.SetActive(false);
            }
            chest2.SetActive(true);
        }
        else if(Time.realtimeSinceStartup > c2time && Time.realtimeSinceStartup < ldrtime)
        {
            if (c2.color.a > 0)
            {
                Color newColor = c2.color;
                float newA = c2.color.a;
                newA -= (2 * Time.deltaTime);
                newColor.a = newA;
                c2.color = newColor;
            }
            else
            {
                chest2.SetActive(false);
            }
            ladder.SetActive(true);
        }
        else
        {
            exit.SetActive(true);
        }
    }
}
