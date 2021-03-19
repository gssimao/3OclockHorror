using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarCntrl : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject rightEnding;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (dist < 1.0f)
        {
            rightEnding.SetActive(true);
        }
    }
}
