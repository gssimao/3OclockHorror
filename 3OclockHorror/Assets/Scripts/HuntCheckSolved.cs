using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntCheckSolved : MonoBehaviour
{
    public GameObject Player;
    public GameObject TP;
    public GameObject Gear1;
    public GameObject Gear2;
    public GameObject Gear3;

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

    float timer = 15.0f;
    bool lost = false;

    //[SerializeField]
    //GameObject isSolved;

    private void Start()
    {
        playermovement.enabled = false;
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

        //TimerText = GameObject.Find("Timer").Text;
    }

    public void Awake()
    {
        timeractive = false;
        ExitButton = GameObject.Find("ExitButton");
        ExitButton.SetActive(false);
        if (GameObject.Find("Jumpscare") != null)
        {
            JumpscareCanvas = GameObject.Find("Jumpscare");
            JumpscareCanvas.SetActive(false);
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
            //yield return new WaitForSeconds(2);
            playermovement.enabled = true;
            GameObject.Find("BeartrapPuzzle").SetActive(false);
        }
    }

    public void ExitPuzzle()
    {
        GameObject.Find("BeartrapPuzzle").SetActive(false);
        playermovement.enabled = true;

    }

    public void Activate(GameObject Puzzle)
    {
        if (!solved)
        {
            Puzzle.SetActive(true);
            if (!timercheck)
            {
                GameObject.Find("Timer").SetActive(false);
                Debug.Log("False TimerCheck");
            }
            else
            {
                Debug.Log("True TimerCheck");
                timeractive = true;
            }
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
                JumpscareCanvas.SetActive(true);
                Player.transform.position = TP.transform.position;
                playermovement.enabled = true;
                GameObject.Find("BeartrapPuzzle").SetActive(false);
                //SolvedText.text = "Lost";
                //Solved.SetActive(true);
                //GameObject.Find("AnswerButton").SetActive(false);
            }
        }

    }
}
