﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntCheckSolved : MonoBehaviour
{
    public sendMessage NeedKeyMessage;
    public GameObject Player;
    public GameObject TP;
    public GameObject Gear1;
    public GameObject Gear2;
    public GameObject Gear3;
    private GameObject timerObject;
    public TrapController TrapCtrl;
    public room basement;

    private int answer1;
    private int answer2;
    private int answer3;

    public PlayerMovement playermovement;
    public int showanswer1;
    public int showanswer2;
    public int showanswer3;

    public Text Text1;
    public Text Text2;
    public Text Text3;
    public GameObject Solved;
    public Text SolvedText;
    public Text TimerText;
    public bool timeractive;
    public GameObject JumpscareCanvas;
    private GameObject ExitButton;

    public bool solved = false;
    //public GameObject clock;
    public bool timercheck;

    bool endTriggered = false;

    float timer = 10.0f;
    bool lost = false;

    AudioManager manager;
    [SerializeField]
    FloorAudioController SoundTrack;
    public bool HunterTrapActive = false; // When this is true, the SoundTrack plays. You can use it or anything else though as well.

    [Space]
    [SerializeField]
    bool isTutorial = false;
    [SerializeField]
    Item key;
    [SerializeField]
    GameObject KeyPopUp;

    //[SerializeField]
    //GameObject isSolved;

    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();

        answer1 = Random.Range(0, 5);
        answer2 = Random.Range(0, 5);
        answer3 = Random.Range(0, 5);
        while (answer2 == answer1 && answer3 == answer1)
        {
            answer1 = Random.Range(0, 5);
            answer2 = Random.Range(0, 5);
            answer3 = Random.Range(0, 5);
        }

        showanswer1 = answer1 + 1;
        showanswer2 = answer2 + 1;
        showanswer3 = answer3 + 1;
        Debug.Log("Answer 1: " + answer1);
        Debug.Log("Answer 2: " + answer2);
        Debug.Log("Answer 3: " + answer3);

        Text1.text = showanswer1.ToString();
        Text2.text = showanswer2.ToString();
        Text3.text = showanswer3.ToString();

        if (TrapCtrl.triggered == 0)
        {
            timer = 15.0f;
        }
        TrapCtrl.triggered++;

        //TimerText = GameObject.Find("Timer").Text;
    }

    public void Awake()
    {
        timeractive = false;
        timerObject = GameObject.Find("Timer");
        ExitButton = GameObject.Find("ExitButton");
        if (GameObject.Find("Jumpscare") != null)
        {
            JumpscareCanvas = GameObject.Find("Jumpscare");
            JumpscareCanvas.SetActive(false);
            ExitButton.SetActive(false);
        }
        else
        {
            ExitButton.SetActive(true);
        }
        GameObject.Find("SolvedText").SetActive(false);
        GameObject.Find("BeartrapPuzzle").SetActive(false);
    }

    public void checkAnswer()
    {
        if (Gear1.GetComponent<GearRotation>().movement == answer1 && Gear2.GetComponent<GearRotation>().movement == answer2 && Gear3.GetComponent<GearRotation>().movement == answer3 && !lost)
        {
            solved = true;
            Solved.SetActive(true);
            GameObject.Find("BeartrapPuzzle").SetActive(false);
            if (manager != null)
            {
                manager.Play("Success", false);
            }

            if(isTutorial)
            {
                if (!playermovement.plyInv.ContainsItem(key))
                {
                    KeyPopUp.SetActive(true);
                    NeedKeyMessage.TriggerMessage();
                }
                else
                {
                    EnterTheHouse ETC = new EnterTheHouse();
                    StartCoroutine(ETC.LoadYourAsyncScene());
                }
            }
        }
    }

    public void ExitPuzzle()
    {
        if (TrapCtrl != null)
        {
            TrapCtrl.DeactivateTraps();
        }
        GameObject.Find("BeartrapPuzzle").SetActive(false);

    }

    public void Activate(GameObject Puzzle)
    {
        if (!solved)
        {
            HunterTrapActive = true;
            if (manager != null && SoundTrack != null)
            {
                manager.Play("Hunter Build up", false);
                SoundTrack.StopSoundTrack();
            }
            Puzzle.SetActive(true);
            if (!timercheck)
            {
                timerObject.SetActive(false);
                Debug.Log("False TimerCheck");
            }
            else
            {
                Debug.Log("True TimerCheck");
                timeractive = true;
            }
        }
        HunterTrapActive = false;
        SoundTrack.StopALL = false;
        if(manager != null)
        {
            manager.Stop("Hunter Build up");
        }
    }

    void Update()
    {
        if (!lost && !solved && timercheck && timeractive)
        {
            timer -= Time.deltaTime;
            TimerText.text = System.Math.Round(timer,2).ToString();
            if(timer <= 0)
            {
                lost = true;
                TrapCtrl.DeactivateTraps();
                JumpscareCanvas.SetActive(true);
                Player.transform.position = TP.transform.position;
                playermovement.myRoom = basement;
                playermovement.enabled = true;
                GameObject.Find("BeartrapPuzzle").SetActive(false);
                //SolvedText.text = "Lost";
                //Solved.SetActive(true);
                //GameObject.Find("AnswerButton").SetActive(false);
            }
        }

    }
}
