using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class page : MonoBehaviour
{
    public GameObject prevPage;
    public GameObject nextPage;
    public Button prev;
    public Button next;
    public Text left;
    public Text right;

    public void ActivateNextButton()
    {
        if(nextPage != null)
        {
            next.gameObject.SetActive(true);
        }
    }

    public void NextPage()
    {
        if(nextPage != null)
        {
            nextPage.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    public void PrevPage()
    {
        if(prevPage != null)
        {
            prevPage.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
