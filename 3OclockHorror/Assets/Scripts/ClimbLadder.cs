using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject dest;
    [SerializeField]
    room destRoom;
    [SerializeField]
    invInput Listener;

    public Vector3 posOffset;

    float dist;

    [Space]

    public Animator Fade;
    public bool transitionOnOff = true; //Use this toggle the transition on and off
    float transitionTime = 0.5f;

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
        dist = Vector3.Distance(this.transform.position + posOffset, player.transform.position);
        if(dist <= 0.75f)
        {
            //Listener.isFocus = false;
            if(uControls.Player.Interact.triggered)
            {
                UpdatePlayer();
            }
        }
    }

    void UpdatePlayer()
    {
        CameraCrossfade(player, dest, player.GetComponent<PlayerMovement>(), destRoom);
        
    }

    void OnDrawGizmos()//Shows how far the play needs to be in order to use the door
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(gameObject.transform.position + posOffset, 0.5f);
        Vector3 plyPos = dest.transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector3(plyPos.x, plyPos.y - 0.3108585f, plyPos.z), new Vector3(0.1573486f, 0.1247783f, 1f));
    }
    private void OnDrawGizmosSelected()//Draws a line between the door and it's destination, which is markered by a red circle
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(gameObject.transform.position, dest.transform.position);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(dest.transform.position, 0.1f);
    }

    public void CameraCrossfade(GameObject player, GameObject entranceP, PlayerMovement play, room RoomNum)
    {
        StartCoroutine(ChangeCamera(player, entranceP, play, RoomNum));
    }

    IEnumerator ChangeCamera(GameObject player, GameObject entranceP, PlayerMovement play, room RoomNum)
    {
        if (transitionOnOff)
        {
            Fade.gameObject.SetActive(true);
            Fade.SetTrigger("fadeOut");
        }
        if (transitionOnOff)
        {
            yield return new WaitForSeconds(transitionTime);
            Fade.SetTrigger("fadeIn");
            player.transform.position = dest.transform.position;
            player.GetComponent<PlayerMovement>().changeRoom(destRoom);
        }

        play.myRoom = RoomNum;
    }
}
