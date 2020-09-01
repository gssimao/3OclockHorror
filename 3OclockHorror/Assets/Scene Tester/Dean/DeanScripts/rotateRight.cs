using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class rotateRight : MonoBehaviour
{
    public bool canRotate;

    public void Update()
    {
        if (canRotate)
        {
            StartCoroutine(Rotate(Vector3.back, 90, 1.0f));
        }
    }

    public void StartRotation()
    {
        canRotate = true;
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;

        Quaternion to = transform.rotation;

        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;

        while (elapsed < duration && canRotate)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
        canRotate = false;
    }
}
