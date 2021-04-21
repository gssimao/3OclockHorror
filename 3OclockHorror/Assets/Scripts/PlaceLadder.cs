using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLadder : MonoBehaviour
{
    [SerializeField]
    Inventory plyInv;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    Item Ladder;
    [SerializeField]
    GameObject invCanvas;
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    GameObject destination;
    [SerializeField]
    room desRoom;

    [Space]
    [SerializeField]
    Animator Fade;
    [SerializeField]
    SpriteRenderer Room;
    [SerializeField]
    Sprite newRoom;

    bool ladAcquired = false;

    float dist;

    [SerializeField]
    string destString;

    UniversalControls uControls;
    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();
    }
    private void OnDisable()
    {
        uControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);

        if (dist <= 0.5f)
        {
            if (ladAcquired)
            {
                if (uControls.Player.Interact.triggered)
                {
                    LadderFunction();
                }
            }
            else if (!ladAcquired)
            {
                if (uControls.Player.Interact.triggered)
                {
                    if (plyInv.ContainsItem(Ladder))
                    {
                        invCanvas.SetActive(true);
                        plyInv.RemoveItem(Ladder);
                        invCanvas.SetActive(false);

                        ladAcquired = true;

                        CallLadderFade();
                    }
                }
            }
        }
        

        if (Fade != null)
        {
            if (Fade.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Fade.gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 0.5f);
    }

    void LadderFunction()
    {
        StartCoroutine(Transition());
    }

    void CallLadderFade()
    {
        StartCoroutine(LadderFadeOut());
    }

    IEnumerator LadderFadeOut()
    {
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("fadeOut");

        yield return new WaitForSeconds(Fade.GetCurrentAnimatorStateInfo(0).length);
        Room.sprite = newRoom;

        Fade.SetTrigger("fadeIn");
    }

    IEnumerator Transition()
    {
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("fadeOut");

        yield return new WaitForSeconds(Fade.GetCurrentAnimatorStateInfo(0).length);

        player.transform.position = destination.transform.position;
        player.myRoom = desRoom;
        player.playerFloor = destString;

        Fade.SetTrigger("fadeIn");
    }
}
