using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class symbolUpdater : MonoBehaviour
{
    [SerializeField]
    Sprite newSprite;

    //This controls the activation of the lights. For now just uses a sprite renderer
    public void UpdateSprite()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = newSprite;
    }
}
