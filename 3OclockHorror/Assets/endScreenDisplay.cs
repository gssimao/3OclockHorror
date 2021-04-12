using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endScreenDisplay : MonoBehaviour
{
    endScreenControl esCntrl;
    public sendMessage gameover1;
    public sendMessage gameover2;
    public sendMessage gameover3;
    public sendMessage gameover4;

    [SerializeField]
    TextMeshProUGUI am;
    [SerializeField]
    TextMeshProUGUI happened;
    private void Awake()
    {
        int random = (int)Random.Range(1,5);
        switch (random)
        {
            case 1:
                gameover1.TriggerMessage();
                break;
            case 2:
                gameover2.TriggerMessage();
                break;
            case 3:
                gameover3.TriggerMessage();
                break;
            case 4:
                gameover4.TriggerMessage();
                break;
            default:
                Debug.Log("Default case");
                break;
        }
    }

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
