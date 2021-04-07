using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveKey : MonoBehaviour
{
    [SerializeField]
    Inventory plyInv;
    [SerializeField]
    Item key;
    [SerializeField]
    Tooltip tooltipScript;
    [SerializeField]
    GameObject invCanv;
    [SerializeField]
    invInput Listener;
    public GameObject KeyPopUp;
    public GameObject UseInventory;
    public GameObject DeadGuyBW;
    AudioManager manager;

    float dist;
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
        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, plyInv.transform.position);

        if (dist <= 0.6f)
        {
            //Listener.isFocus = false;

            if (uControls.Player.Interact.triggered)
            {
                if (manager != null)
                {
                    manager.Play("Key pickup", true);
                }
                KeyPopUp.SetActive(true);
                UseInventory.SetActive(true);
                DeadGuyBW.SetActive(true);
                invCanv.SetActive(true);
                plyInv.AddItem(key);
                invCanv.SetActive(false);
                //tooltipScript.TimedMessage = "There's a key in the pocket";
            }
        }
    }
}
