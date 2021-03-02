using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePopUp : MonoBehaviour
{
    public float timer = 2f;
    public bool done = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        LeanTween.alpha(gameObject, 1f, .7f);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && !done)
        {
            done = true;
            FadeoutAlpha();
        }
    }
    private void FadeoutAlpha()
    {
        //fade out with leanTween
        LeanTween.value(gameObject, 1f, 0, .5f).setOnUpdate((float val) =>
        {
            SpriteRenderer ImageTutorial = gameObject.GetComponent<SpriteRenderer>();
            Color newColor = ImageTutorial.color;
            newColor.a = val; // changing Alpha
            ImageTutorial.color = newColor;
        });
        if (done)
        {
            Destroy(this.gameObject);
        }
    }
}
