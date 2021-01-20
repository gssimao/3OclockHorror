using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateContainer : MonoBehaviour
{
    [SerializeField]
    ContainerControl myContainer;
    [SerializeField]
    SpriteRenderer sr;
    [SerializeField]
    Sprite filled;
    [SerializeField]
    Sprite empty;

    // Update is called once per frame
    void Update()
    {
        if(myContainer.getItemCount() == 0)
        {
            sr.sprite = empty;
        }
        else
        {
            sr.sprite = filled;
        }
    }
}
