using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBeartrap : MonoBehaviour
{
    public HuntCheckSolved AnswerCheck;
    public GameObject Puzzle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnswerCheck.GetComponent<HuntCheckSolved>().Activate(Puzzle);
    }
}
