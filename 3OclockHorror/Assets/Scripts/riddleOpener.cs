using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riddleOpener : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject riddleCanv;
    [SerializeField]
    GameObject riddle;
    [SerializeField]
    invInput Listener;
    [SerializeField]
    KeyCode interactKey;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, this.transform.position);

        if (dist <= 0.45f)
        {
            Listener.enabled = false;
            if (Input.GetKeyDown(interactKey))
            {
                riddleCanv.SetActive(true);
                riddle.SetActive(true);
            }
        }
    }
}
