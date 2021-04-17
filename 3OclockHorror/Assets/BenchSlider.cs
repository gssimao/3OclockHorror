using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchSlider : MonoBehaviour
{
    bool moving = false;
    float time;
    bool childplace;
    [SerializeField]
    RecipieHolder holder;
    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup > time + 2f && moving)
        {
            LeanTween.moveLocalY(this.gameObject, -92.955f, 1f);
            holder.Craft();
            moving = false;
        }
        if(Time.realtimeSinceStartup > time + 4f && childplace)
        {
            this.gameObject.transform.SetSiblingIndex(1);
            childplace = false;
        }
    }

    public void slideSlider()
    {
        this.gameObject.transform.SetAsLastSibling();
        LeanTween.moveLocalY(this.gameObject, 135f, 1f);
        moving = true;
        time = Time.realtimeSinceStartup;
        childplace = true;
    }
}
