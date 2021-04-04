using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallHouseText : MonoBehaviour
{
    [SerializeField] public Writer textWriter;
    public Text dialog;
    string message = "teeeesstt 12345601 29309 12031209302 1930910219 309102 193091021 9309102 193 0910219 3091021 930910 219309129";
    //this is where the maneger will decide what to play and when to play it.

    private void Start() // this is for testing
    {
        textWriter.AddWriter(dialog, message, .1f, true);
    }
    public void WriteString(string message) // this is where the calls will happen
    {
        textWriter.AddWriter(dialog, message, .1f, true);
    }
}
