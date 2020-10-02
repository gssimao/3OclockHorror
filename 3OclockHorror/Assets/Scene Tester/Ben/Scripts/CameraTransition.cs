using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void CameraCrossfade()
    {
        StartCoroutine(ChangeCamera());
    }

    IEnumerator ChangeCamera()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }
}
