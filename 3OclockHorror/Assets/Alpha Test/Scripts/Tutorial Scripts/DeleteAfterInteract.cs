using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterInteract : MonoBehaviour
{
    public bool UseE;
    public bool UseQ;
    public bool UseWASD;
    public bool UseInventory;
    public bool isDone = false;
    public bool enter = false;
    private void Awake()
    {
        SpriteRenderer ImageTutorial = gameObject.GetComponent<SpriteRenderer>();
        Color newColor = ImageTutorial.color;
        newColor.a = 0; // changing Alpha to zero
        ImageTutorial.color = newColor;
    }
    private void Update()
    {
        if(UseE && Input.GetKeyDown(KeyCode.E) && enter)
        {
            FadeoutAlpha();
            isDone = true;
        }
        if(UseQ && Input.GetKeyDown(KeyCode.Q) && enter)
        {
            FadeoutAlpha();
            isDone = true;
        }
        if (UseWASD && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) && enter)
        {
            FadeoutAlpha();
            isDone = true;
        }
        if(UseInventory && Input.GetKeyDown(KeyCode.E) && enter)
        {
            FadeoutAlpha();
            isDone = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //fade in with leanTween
        LeanTween.alpha(gameObject, 1f, .7f);
        enter = true;
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        FadeoutAlpha();
        enter = false;
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
        if(isDone)
        { 
            Destroy(this.gameObject);
        }
    }
}
