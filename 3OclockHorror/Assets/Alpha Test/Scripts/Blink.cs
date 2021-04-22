using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public float LoopTime = 5;
    public float AlphaMax = .6f;
    public Image image;
    // Start is called before the first frame update
    private void Awake()
    {
        Color newColor = image.color;
        newColor.a = 0; // changing Alpha to zero
        image.color = newColor;
        FadeStart();
    }

    // Update is called once per frame
    void FadeStart()
    {
        LeanTween.alpha(image.rectTransform, 0f, LoopTime).setEase(LeanTweenType.linear).setOnComplete(FadeFinished);
    }
    void FadeFinished()
    {
        LeanTween.alpha(image.rectTransform, AlphaMax, LoopTime).setEase(LeanTweenType.linear).setOnComplete(FadeStart);
    }

}
