using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text TooltipText;
    private bool walked = false;
    // Start is called before the first frame update
    void Start()
    {
        TooltipText = GameObject.Find("TooltipText").GetComponent<Text>();
        TooltipText.text = "Use 'WASD' to move";
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player2").GetComponent<PlayerMovement>().walking == true && walked == false)
        {
            TooltipText.text = "";
            walked = true;
        }
    }
}
