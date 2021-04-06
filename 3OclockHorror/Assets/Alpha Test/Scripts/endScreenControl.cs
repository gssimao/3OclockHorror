using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreenControl : MonoBehaviour
{
    public string endMessage;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
