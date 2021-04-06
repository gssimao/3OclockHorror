using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endScreenDisplay : MonoBehaviour
{
    endScreenControl esCntrl;

    [SerializeField]
    TextMeshProUGUI am;
    [SerializeField]
    TextMeshProUGUI happened;

    // Start is called before the first frame update
    void Start()
    {
        esCntrl = FindObjectOfType<endScreenControl>();
        if(esCntrl.endMessage == "You ran out of time.")
        {
            am.gameObject.SetActive(true);
            happened.text = esCntrl.endMessage;
        }
        else
        {
            am.gameObject.SetActive(false);
            happened.text = esCntrl.endMessage;
        }
    }
}
