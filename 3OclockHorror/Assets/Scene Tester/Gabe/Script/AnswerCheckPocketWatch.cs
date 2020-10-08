using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        answerBig = Random.Range(0, 12);
        answerMed = Random.Range(0, 5);
        answerSmall = Random.Range(0, 2);

        showAnswerBig = answerBig + 1;
        showAnswerMed = answerMed + 1;
        showAnswerSmall = answerSmall + 1;


    }

    // Update is called once per frame
    void Update()
    {
        if(medGear.GetComponent<RotationMedGear>().Medmovement == answerMed && smallGear.GetComponent<RotationSmallGear>().Smallmovement == answerSmall && bigGear.GetComponent<RotationBigGear>().Bigmovement == answerBig)
        {
            Debug.Log("YOU DID IT YAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAYYYY");
        }
       
    }
}

//medGear.GetComponent<RotationMedGear>().Medmovement
//smallGear.GetComponent<RotationSmallGear>().Smallmovement
// BigGear.GetComponent<RotationBigGear>().Bigmovement