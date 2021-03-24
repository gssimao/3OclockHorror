using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarCntrl : MonoBehaviour
{
    [SerializeField]
    List<SpriteRenderer> pillars;

    [Space]
    [SerializeField]
    Sprite pillarOne;
    [SerializeField]
    Sprite pillarTwo;
    [SerializeField]
    Sprite pillarThree;

    public void updatePilar(string stage)
    {
        if(stage == "stage1")
        {
            foreach(SpriteRenderer sr in pillars)
            {
                sr.sprite = pillarOne;
            }
        }
        else if (stage == "stage2")
        {
            foreach (SpriteRenderer sr in pillars)
            {
                sr.sprite = pillarTwo;
            }
        }
        else if (stage == "stage3")
        {
            foreach (SpriteRenderer sr in pillars)
            {
                sr.sprite = pillarThree;
            }
        }
    }
}
