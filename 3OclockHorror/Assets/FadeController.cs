using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FadeController : MonoBehaviour
{
    [SerializeField]
    GameObject Fade;
    [SerializeField]
    Animator fadeAnim;

    static GameObject FadeS;
    static Animator fadeAnimS;

    public static Action FadeOut = delegate { };
    // Start is called before the first frame update
    void Awake()
    {
        FadeS = Fade;
        fadeAnimS = fadeAnim;
    }

    void PlayFadeOutFadeIn()
    {

    }

    void PlayFadeOut()
    {

    }
}
