using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerCheckPocketWatch : MonoBehaviour
{
    public GameObject bigGear;
    public GameObject medGear;
    public GameObject smallGear;
    
    private int answerMed;
    private int answerBig;
    private int answerSmall;

    public int showAnswerMed;
    public int showAnswerBig;
    public int showAnswerSmall;

    public Text BigText;
    public Text MedText;
    public Text SmallText;

    public bool solved = false;
    public GameObject clock;

    public Inventory pInv;
    public Item cKey;

    bool endTriggered = false;

    [SerializeField]
    GameObject isSolved;

    AudioManager manager;

    private void Start()
    {
        answerBig = Random.Range(0, 12);
        answerMed = Random.Range(0, 5);
        answerSmall = Random.Range(0, 2);
        while(answerBig == answerMed || answerSmall == answerMed)
        {
            answerMed = Random.Range(0, 5);
        }

        while (answerBig == answerSmall || answerSmall == answerMed)
        {
            answerSmall = Random.Range(0, 2);
        }

        showAnswerBig = answerBig + 1;
        showAnswerMed = answerMed + 1;
        showAnswerSmall = answerSmall + 1;

        BigText.text = showAnswerBig.ToString();
        MedText.text = showAnswerMed.ToString();
        SmallText.text = showAnswerSmall.ToString();

        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(medGear.GetComponent<RotationMedGear>().Medmovement == answerMed && smallGear.GetComponent<RotationSmallGear>().Smallmovement == answerSmall && bigGear.GetComponent<RotationBigGear>().Bigmovement == answerBig)
        {
            solved = true;
            manager.Play("Success");
        }

        if (solved && !endTriggered)
        {
            startClock();
        }
    }

    public void startClock()
    {
        isSolved.SetActive(true);
        isSolved.transform.SetAsLastSibling();

        clock.SetActive(true);
        if(pInv != null && cKey != null && !endTriggered)
        {
            pInv.AddItem(cKey);
        }
        endTriggered = true;
    }
}

//medGear.GetComponent<RotationMedGear>().Medmovement
//smallGear.GetComponent<RotationSmallGear>().Smallmovement
// BigGear.GetComponent<RotationBigGear>().Bigmovement