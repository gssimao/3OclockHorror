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
    public bool isLetter = false;
    bool active = false;

    UniversalControls uControls;
    private void Awake()
    {
        uControls = new UniversalControls();
        uControls.Enable();

        SpriteRenderer ImageTutorial = gameObject.GetComponent<SpriteRenderer>();
        Color newColor = ImageTutorial.color;
        newColor.a = 0; // changing Alpha to zero
        ImageTutorial.color = newColor;
    }

    private void OnDisable()
    {
        uControls.Disable();
    }

    private void Update()
    {
        if(UseE && uControls.Player.Interact.triggered && enter)
        {
            FadeoutAlpha();
            isDone = true;
        }
        if(UseQ && uControls.Player.Light.triggered && enter)
        {
            FadeoutAlpha();
            isDone = true;
        }
        if (UseWASD && uControls.Player.MovePlayer.triggered && enter)
        {
            FadeoutAlpha();
            isDone = true;
        }
        if(UseInventory && uControls.Player.Interact.triggered && enter)
        {
            FadeoutAlpha();
            isDone = true;
        }
        if(isLetter && uControls.Player.Interact.triggered && enter && !active)
        {
            LeanTween.alpha(gameObject, 1f, .7f);
            active = true;
        }
        else if(isLetter && uControls.Player.Interact.triggered && enter && active)
        {
            LeanTween.alpha(gameObject, 0, .7f);
            active = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isLetter)
        {
            //fade in with leanTween
            LeanTween.alpha(gameObject, 1f, .7f);
        }
        else if(isLetter)
        {
            Tooltip.Message = "E";
        }
            enter = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isLetter)
        {
            FadeoutAlpha();
        }
        else if (isLetter)
        {
            Tooltip.Message = "";
        }
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

    void FadeInAlpha()
    {
        LeanTween.value(gameObject, 0, 1f, .5f).setOnUpdate((float val) =>
        {
            SpriteRenderer ImageTutorial = gameObject.GetComponent<SpriteRenderer>();
            Color newColor = ImageTutorial.color;
            newColor.a = val; // changing Alpha
            ImageTutorial.color = newColor;
        });
    }
}
