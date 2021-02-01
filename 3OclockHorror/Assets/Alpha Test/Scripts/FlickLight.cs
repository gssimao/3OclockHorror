using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickLight : MonoBehaviour
{
    public SpriteMask spriteMask;
    public Material lightEffect;
    public float flick;
    public float amplitude = 0.3f;
    public float omega = 1.0f;
    float index;

    // Start is called before the first frame update
    void Start()
    {
        spriteMask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        index += Time.deltaTime;
        //flick = Random.Range(0f, 0.2f);

        flick = Mathf.Abs(amplitude * Mathf.Sin(omega*index));
        spriteMask.alphaCutoff = flick;

        //_LightWave
        lightEffect.SetFloat("_LightWave", 0.3f + flick);
    }
}
