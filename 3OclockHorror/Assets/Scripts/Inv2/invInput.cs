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
    }
    private void OnDisable()
    {
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
        bool puzOpen = false;
        foreach(GameObject obj in objs)
        {
            if(obj.activeSelf)
            {
                puzOpen = true;
            }
        }

        if (isFocus)
        {
            if (uControls.Player.Interact.triggered && !jInput.isFocused && !puzOpen)
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
        if (uControls.Player.PauseMenu.triggered)
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