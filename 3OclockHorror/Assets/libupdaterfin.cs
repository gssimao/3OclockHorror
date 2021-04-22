using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class libupdaterfin : MonoBehaviour
{
    public Sprite libraryFin;

    public void updateSpriteFinal()
    {
        this.GetComponent<SpriteRenderer>().sprite = libraryFin;
    }
}
