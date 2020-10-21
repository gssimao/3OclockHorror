using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalFunction : MonoBehaviour
{
    public GameObject jounralUI;

    float originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        /*originalPosition = jounralUI.transform.position.y;
        jounralUI.transform.position = new Vector3(jounralUI.transform.position.x, -originalPosition, jounralUI.transform.position.z);*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            SetJounralToggle();
            FindObjectOfType<AudioManager>().Play("Journal");
        }
    }
    public void SetJounralToggle()
    {
        if(jounralUI.activeSelf)
        {
            jounralUI.SetActive(false);
        }
        else
        {
            jounralUI.SetActive(true);
        }

        /*if (jounralUI.transform.position.y == originalPosition)
        {
            LeanTween.moveY(jounralUI, -originalPosition, 1.3f).setEaseInOutSine();
        }
        else
        {
            LeanTween.moveY(jounralUI, originalPosition, 1.3f).setEaseInOutSine();
        */
    }
}
