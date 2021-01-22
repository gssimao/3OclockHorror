using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invInput : MonoBehaviour
{

    [SerializeField]
    KeyCode invKey;
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

        if (Input.GetKeyDown(invKey) && !jInput.isFocused && !puzOpen)
        {
            if (Journal.activeSelf)
            {
                Journal.SetActive(false);
            }
            else
            {
                Journal.SetActive(true);
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

    public void ClearObjsList()//Used for changing scenes
    {
        objs.Clear();
    }
}
