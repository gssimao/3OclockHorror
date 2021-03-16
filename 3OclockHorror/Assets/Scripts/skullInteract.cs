using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullInteract : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    SkullTurning turner;
    [Space]
    [SerializeField]
    int skull;
    [SerializeField]
    KeyCode interactKey;
    [SerializeField]
    invInput Listener;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, this.transform.position);
        
        if (dist <= 0.25f) {
            Listener.isFocus = false;
            if (Input.GetKeyDown(interactKey)) {
                switch (skull)
                {
                    case 1:
                        turner.Turning1();
                        break;
                    case 2:
                        turner.Turning2();
                        break;
                    case 3:
                        turner.Turning3();
                        break;
                    case 4:
                        turner.Turning4();
                        break;
                }
            }
        }
    }
}
