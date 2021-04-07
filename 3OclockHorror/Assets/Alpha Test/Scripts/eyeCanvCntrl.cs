using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeCanvCntrl : MonoBehaviour
{
    [SerializeField]
    AnxEffect anxiety;
    [SerializeField]
    GameObject bigEye;
    [SerializeField]
    Animator anim;

    [SerializeField]
    List<GameObject> eyes;
    [SerializeField]
    GameObject prefEye; //The eye prefab that the little eyes will come from

    [SerializeField]
    float perChance; //The initial percent chance an eye spawns on a given tick

    float maxX;
    float maxY;

    void Start()
    {
        maxX = this.GetComponent<RectTransform>().rect.width;
        maxY = this.GetComponent<RectTransform>().rect.height;

        bigEye.transform.position = new Vector3(maxX / 2, maxY - 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (anxiety.anxActive)
        {
            if (!anxiety.timeUp)
            {
                resetCanv();
                anim.SetBool("animate", false);
            }
            else
            {
                anim.SetBool("animate", true);

                int x = Random.Range(0, 100);
                if(x <= perChance)
                {
                    makeEye();
                }

                if(perChance <= 90)
                {
                    perChance += Time.deltaTime / 2;
                }
            }
        }
    }

    public void resetCanv()
    {
        foreach(GameObject eye in eyes)
        {
            Destroy(eye);
        }
    }

    public void makeEye()
    {
        float x = Random.Range(0, maxX);
        float y = Random.Range(0, maxY);

        GameObject eye = Instantiate(prefEye, new Vector3(x, y), new Quaternion(0, 0, 0, 0), this.transform);
        eye.transform.SetAsFirstSibling();
        eyes.Add(eye);
    }
}
