using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Message
{
    public string nameID;

    [TextArea (3,15)]
    public string[] messagesToWrite;
}
