using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invInput : MonoBehaviour
{
    [SerializeField]
    KeyCode invKey;
    [SerializeField]
    KeyCode escKey;
    [SerializeField]
    GameObject Journal;
    [SerializeField]
    GameObject invCanvas;
    [SerializeField]
    GameObject tooltip;
    [SerializeField]
    InputField jInput;
    [SerializeField]
    List<GameObject> objs;
    [SerializeField]
    GameObject escCanv;

    AudioManager manager;
    public bool isFocus = true;

    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        bool puzOpen = false;
        foreach(GameObject obj in objs)
        {
            if(obj.activeSelf)
            {
                puzOpen = true;
            }
        }

        if (isFocus)
        {
            if (Input.GetKeyDown(invKey) && !jInput.isFocused && !puzOpen)
            {
                if (Journal.activeSelf)
                {
                    Journal.SetActive(false);
                    playSound();

                }
                else
                {
                    Journal.SetActive(true);
                    playSound();
                }

                /*
                if (invCanvas.activeSelf)
                {
                    tooltip.SetActive(false);
                    invCanvas.SetActive(false);
                }
                else
                {
                    invCanvas.SetActive(true);
                }
                */

            }
        }
        if (Input.GetKeyDown(escKey))
        {
            if (!escCanv.activeSelf)
            {
                escCanv.SetActive(true);
            }
            else
            {
                escCanv.SetActive(false);
            }
        }
        isFocus = true;
    }

    void playSound()
    {
        if (manager != null)
        {
            manager.Play("Journal", true);
        }
    }
}