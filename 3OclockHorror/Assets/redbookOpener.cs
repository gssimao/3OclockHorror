using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redbookOpener : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bookCanv;
    [Space]
    [SerializeField]
    KeyCode interactKey;
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        if(dist < 0.5 && Input.GetKeyDown(interactKey) && !bookCanv.activeSelf)
        {
            bookCanv.SetActive(true);
        }
    }
}
