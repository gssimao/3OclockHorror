using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheckPocketWatch : MonoBehaviour
{
    public GameObject bigGear;
    public GameObject medGear;
    public GameObject smallGear;

    public int answerBig;
    public int answerMed;
    public int answerSmall;
    private void Start()
    {
        answerBig = Random.Range(0, 12);
        answerMed = Random.Range(0, 5);
        answerSmall = Random.Range(0, 2);
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