using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combination : MonoBehaviour
{

    public GameObject bigStar;
    public GameObject medStar;
    public GameObject smallStar;

    public Image Hunter1;
    public Image Hunter2;
    public Image Hunter3;

    public Image Blind1;
    public Image Blind2;
    public Image Blind3;

    public Image Watcher1;
    public Image Watcher2;
    public Image Watcher3;

    public Image Player1;
    public Image Player2;
    public Image Player3;


    public Image Hunter1Visual;
    public Image Hunter2Visual;
    public Image Hunter3Visual;

    public Image Blind1Visual;
    public Image Blind2Visual;
    public Image Blind3Visual;

    public Image Watcher1Visual;
    public Image Watcher2Visual;
    public Image Watcher3Visual;

    public Image Player1Visual;
    public Image Player2Visual;
    public Image Player3Visual;

    public bool Hunter1V = false;
    public bool Hunter2V = false;
    public bool Hunter3V = false;

    public bool Blind1V = false;
    public bool Blind2V = false;
    public bool Blind3V = false;

    public bool Watcher1V = false;
    public bool Watcher2V = false;
    public bool Watcher3V = false;

    public bool Player1V = false;
    public bool Player2V = false;
    public bool Player3V = false;


    /*  bigStar.GetComponent<BackImage>().StarLocation /// this is a reference to the location in their script
        medStar.GetComponent<BackImage>().StarLocation
        smallStar.GetComponent<BackImage>().StarLocation
    */

    private void Start()
    {
        HideorShowImage(Player1, false);
        HideorShowImage(Watcher1, false);
        HideorShowImage(Blind1, false);
        HideorShowImage(Hunter1, false);

        HideorShowImage(Player2, false);
        HideorShowImage(Watcher2, false);
        HideorShowImage(Blind2, false);
        HideorShowImage(Hunter2, false);

        HideorShowImage(Player3, false);
        HideorShowImage(Watcher3, false);
        HideorShowImage(Blind3, false);
        HideorShowImage(Hunter3, false);

        HideorShowImage(Player1Visual, false);
        HideorShowImage(Watcher1Visual, false);
        HideorShowImage(Blind1Visual, false);
        HideorShowImage(Hunter1Visual, false);

        HideorShowImage(Player2Visual, false);
        HideorShowImage(Watcher2Visual, false);
        HideorShowImage(Blind2Visual, false);
        HideorShowImage(Hunter2Visual, false);

        HideorShowImage(Player3Visual, false);
        HideorShowImage(Watcher3Visual, false);
        HideorShowImage(Blind3Visual, false);
        HideorShowImage(Hunter3Visual, false);
    }

    public void callImage()
    {
        updateAlphaBackStar(bigStar.GetComponent<BackImage>().StarLocation);
        updateAlphaMiddleStar(medStar.GetComponent<BackImage>().StarLocation);
        updateAlphaFrontStar(smallStar.GetComponent<BackImage>().StarLocation);

        //test if that is the correct answer
    }

    public void revelImage(string symbol)
    {
        //if the player had found a symbol in the game then revel it in the amulet
        switch (symbol)
        {
            case "Player1": //player1
                HideorShowImage(Player1Visual, true);
                Player1V = true;
                break;
            case "Bind1": //blind1 Symbol on
                HideorShowImage(Blind1Visual, true);
                Blind1V = true;
                break;
            case "Watcher1": //watcher1 Symbol on
                HideorShowImage(Watcher1Visual, true);
                Watcher1V = true;
                break;
            case "Hunter1": // Hunter1 Symbol on
                HideorShowImage(Hunter1Visual, true);
                Hunter1V = true;
                break;
            case "Player2": //player2 Symbol on
                HideorShowImage(Player2Visual, true);
                Player2V = true;
                break;
            case "Bind2": //blind2 Symbol on
                HideorShowImage(Blind2Visual, true);
                Blind2V = true;
                break;
            case "Watcher2": //watcher2 Symbol on
                HideorShowImage(Watcher2Visual, true);
                Watcher2V = true;
                break;
            case "Hunter2": // Hunter2 Symbol on
                HideorShowImage(Hunter2Visual, true);
                Hunter2V = true;
                break;
            case "Player3": //player3 Symbol on
                HideorShowImage(Player3Visual, true);
                Player3V = true;
                break;
            case "Bind3": //blind3 Symbol on
                HideorShowImage(Blind3Visual, true);
                Blind3V = true;
                break;
            case "Watcher3": //watcher3 Symbol on
                HideorShowImage(Watcher3Visual, true);
                Watcher3V = true;
                break;
            case "Hunter3": // Hunter3 Symbol on
                HideorShowImage(Hunter3Visual, true);
                Hunter3V = true;
                break;
            default:
                Debug.Log("No word match, CHECK SYMBOL STRING being passed to revelImage()");
                break;
        }

    }


    private void updateAlphaBackStar(int moviment)
    {

        switch (moviment)
        {
            case 0: //player
                if(Player1V)
                {
                    HideorShowImage(Player1, true);   //show player.
                    HideorShowImage(Watcher1, false); // hide watcher,
                    HideorShowImage(Blind1, false);   // hide blind, and
                    HideorShowImage(Hunter1, false);  // hide hunter.
                }
                else
                {
                    HideorShowImage(Player1, false);
                    HideorShowImage(Watcher1, false);
                    HideorShowImage(Blind1, false);
                    HideorShowImage(Hunter1, false);
                }
                
                break;
            case 1: //blind
                if(Blind1V)
                {
                    HideorShowImage(Player1, false);
                    HideorShowImage(Watcher1, false);
                    HideorShowImage(Blind1, true);
                    HideorShowImage(Hunter1, false);
                }
                else
                {
                    HideorShowImage(Player1, false);
                    HideorShowImage(Watcher1, false);
                    HideorShowImage(Blind1, false);
                    HideorShowImage(Hunter1, false);
                }

                break;
            case 2: //watcher
                if(Watcher1V)
                {
                    HideorShowImage(Player1, false);
                    HideorShowImage(Watcher1, true);
                    HideorShowImage(Blind1, false);
                    HideorShowImage(Hunter1, false);
                }
                else
                {
                    HideorShowImage(Player1, false);
                    HideorShowImage(Watcher1, false);
                    HideorShowImage(Blind1, false);
                    HideorShowImage(Hunter1, false);
                }

                break;
            case 3: // Hunter
                if(Hunter1V)
                {
                    HideorShowImage(Player1, false);
                    HideorShowImage(Watcher1, false);
                    HideorShowImage(Blind1, false);
                    HideorShowImage(Hunter1, true);
                }
                else
                {
                    HideorShowImage(Player1, false);
                    HideorShowImage(Watcher1, false);
                    HideorShowImage(Blind1, false);
                    HideorShowImage(Hunter1, false);
                }

                break;

            default:
                Debug.Log("OUT OF BOUNDS");
                break;
        }
        
    }
    private void updateAlphaMiddleStar(int moviment)
    {
        switch (moviment)
        {
            case 0: //watcher
                if(Watcher2V)
                {
                    HideorShowImage(Player2, false);
                    HideorShowImage(Watcher2, true);
                    HideorShowImage(Blind2, false);
                    HideorShowImage(Hunter2, false);
                }
                else
                {
                    HideorShowImage(Player2, false);
                    HideorShowImage(Watcher2, false);
                    HideorShowImage(Blind2, false);
                    HideorShowImage(Hunter2, false);
                }

                break;
            case 1: //Hunter
                if(Hunter2V)
                {
                    HideorShowImage(Player2, false);
                    HideorShowImage(Watcher2, false);
                    HideorShowImage(Blind2, false);
                    HideorShowImage(Hunter2, true);
                }
                else
                {
                    HideorShowImage(Player2, false);
                    HideorShowImage(Watcher2, false);
                    HideorShowImage(Blind2, false);
                    HideorShowImage(Hunter2, false);
                }
                break;
            case 2: // Blind
                if(Blind2V)
                {
                    HideorShowImage(Player2, false);
                    HideorShowImage(Watcher2, false);
                    HideorShowImage(Blind2, true);
                    HideorShowImage(Hunter2, false);
                }
                else
                {
                    HideorShowImage(Player2, false);
                    HideorShowImage(Watcher2, false);
                    HideorShowImage(Blind2, false);
                    HideorShowImage(Hunter2, false);
                }
                break;
            case 3: // player
                if(Player2V)
                {
                    HideorShowImage(Player2, true);
                    HideorShowImage(Watcher2, false);
                    HideorShowImage(Blind2, false);
                    HideorShowImage(Hunter2, false);
                }
                else
                {
                    HideorShowImage(Player2, false);
                    HideorShowImage(Watcher2, false);
                    HideorShowImage(Blind2, false);
                    HideorShowImage(Hunter2, false);
                }
                break;

            default:
                Debug.Log("OUT OF BOUNDS");
                break;
        }

    }
    private void updateAlphaFrontStar(int moviment)
    {
        switch (moviment)
        {
            case 0: //watcher
                if(Watcher3V)
                {
                    HideorShowImage(Player3, false);
                    HideorShowImage(Watcher3, true);
                    HideorShowImage(Blind3, false);
                    HideorShowImage(Hunter3, false);
                }
                else
                {
                    HideorShowImage(Player3, false);
                    HideorShowImage(Watcher3, false);
                    HideorShowImage(Blind3, false);
                    HideorShowImage(Hunter3, false);
                }
                break;
            case 1: // Payer
                if(Player3V)
                {
                    HideorShowImage(Player3, true);
                    HideorShowImage(Watcher3, false);
                    HideorShowImage(Blind3, false);
                    HideorShowImage(Hunter3, false);
                }
                else
                {
                    HideorShowImage(Player3, false);
                    HideorShowImage(Watcher3, false);
                    HideorShowImage(Blind3, false);
                    HideorShowImage(Hunter3, false);
                }
                break;
            case 2: //Blind
                if(Blind3V)
                {
                    HideorShowImage(Player3, false);
                    HideorShowImage(Watcher3, false);
                    HideorShowImage(Blind3, true);
                    HideorShowImage(Hunter3, false);
                }
                else
                {
                    HideorShowImage(Player3, false);
                    HideorShowImage(Watcher3, false);
                    HideorShowImage(Blind3, false);
                    HideorShowImage(Hunter3, false);
                }
                break;
            case 3: // Hunter
                if(Hunter3V)
                {
                    HideorShowImage(Player3, false);
                    HideorShowImage(Watcher3, false);
                    HideorShowImage(Blind3, false);
                    HideorShowImage(Hunter3, true);
                }
                else
                {
                    HideorShowImage(Player3, false);
                    HideorShowImage(Watcher3, false);
                    HideorShowImage(Blind3, false);
                    HideorShowImage(Hunter3, false);
                }
                break;

            default:
                Debug.Log("OUT OF BOUNDS");
                break;
        }

    }

    public void HideorShowImage(Image symbol, bool Show)
    {
        Color tempSymbol;
        tempSymbol = symbol.color;

        if (Show) // if show is True then SHOW
        {
            tempSymbol.a = 1f;
        }
        else // if show is FALSE then HIDE
        {
            tempSymbol.a = 0f;
        }
        symbol.color = tempSymbol;
    }
}
