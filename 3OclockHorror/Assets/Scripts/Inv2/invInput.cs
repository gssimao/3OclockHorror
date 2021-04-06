using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class invInput : MonoBehaviour
{
    [SerializeField]
    KeyCode invKey;
    [SerializeField]
    KeyCode escKey;
    [SerializeField]
    GameObject Journal;
    [SerializeField]
    GameObject invCanvas;
    [SerializeField]
    GameObject tooltip;
    [SerializeField]
    InputField jInput;
    [SerializeField]
    List<GameObject> objs;
    [SerializeField]
    GameObject escCanv;

    AudioManager manager;
    public bool isFocus = true;

    private UniversalControls uControls;
    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();
        uControls.Player.Interact.performed += ShowJournal;
        uControls.Player.PauseMenu.performed += ShowPauseMenu;
    }
    private void OnDisable()
    {
        uControls.Player.PauseMenu.performed -= ShowPauseMenu;
        uControls.Player.Interact.performed -= ShowJournal;
        uControls.Disable();
    }

    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }

    private void ShowJournal(InputAction.CallbackContext c)
    {
        if (isFocus)
        {
            if (!jInput.isFocused)
            {
                if (Journal.activeSelf)
                {
                    Journal.SetActive(false);
                    playSound();

                }
                else
                {
                    Journal.SetActive(true);
                    playSound();
                }

                /*
                if (invCanvas.activeSelf)
                {
                    tooltip.SetActive(false);
                    invCanvas.SetActive(false);
                }
                else
                {
                    invCanvas.SetActive(true);
                }
                */
            }
        }
    }

    void ShowPauseMenu(InputAction.CallbackContext c)
    {
        if (!escCanv.activeSelf)
        {
            escCanv.SetActive(true);
        }
        else
        {
            escCanv.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //bool puzOpen = false;
        foreach(GameObject obj in objs)
        {
            if(obj.activeSelf)
            {
                isFocus = false;
            }
        }

        /*if (isFocus)
        {
            if (Input.GetKeyDown(invKey) && !jInput.isFocused && !puzOpen)
            {
                if (Journal.activeSelf)
                {
                    Journal.SetActive(false);
                    playSound();

                }
                else
                {
                    Journal.SetActive(true);
                    playSound();
                }
            }
        }
        if (Input.GetKeyDown(escKey))
        {
            if (!escCanv.activeSelf)
            {
                escCanv.SetActive(true);
            }
            else
            {
                escCanv.SetActive(false);
            }
        }*/
        isFocus = true;
    }

    void playSound()
    {
        if (manager != null)
        {
            manager.Play("Journal", true);
        }
    }

    /*private void Interact(InputAction.CallbackContext c)
    {

    }*/
}