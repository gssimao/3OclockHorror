using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LockControl : MonoBehaviour, IPointerClickHandler
{
    public string numeral = "I";

    [Space]

    [SerializeField]
    Image left;
    [SerializeField]
    Image center;
    [SerializeField]
    Image right;

    [Space]

    [SerializeField]
    Sprite numeralI;
    [SerializeField]
    Sprite numeralII;
    [SerializeField]
    Sprite numeralIII;
    [SerializeField]
    Sprite numeralIV;
    [SerializeField]
    Sprite numeralV;
    [SerializeField]
    Sprite numeralVI;
    [SerializeField]
    Sprite numeralVII;
    [SerializeField]
    Sprite numeralVIII;
    [SerializeField]
    Sprite numeralIX;
    [SerializeField]
    Sprite numeralX;

    public void Start()
    {
        left.sprite = numeralX;
        center.sprite = numeralI;
        right.sprite = numeralII;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateNumeral();
    }

    public void UpdateNumeral()
    {
        switch (numeral)
        {
            case "I":
                numeral = "II";
                left.sprite = numeralI;
                center.sprite = numeralII;
                right.sprite = numeralIII;
                break;
            case "II":
                numeral = "III";
                left.sprite = numeralII;
                center.sprite = numeralIII;
                right.sprite = numeralIV;
                break;
            case "III":
                numeral = "IV";
                left.sprite = numeralIII;
                center.sprite = numeralIV;
                right.sprite = numeralV;
                break;
            case "IV":
                numeral = "V";
                left.sprite = numeralIV;
                center.sprite = numeralV;
                right.sprite = numeralVI;
                break;
            case "V":
                numeral = "VI";
                left.sprite = numeralV;
                center.sprite = numeralVI;
                right.sprite = numeralVII;
                break;
            case "VI":
                numeral = "VII";
                left.sprite = numeralVI;
                center.sprite = numeralVII;
                right.sprite = numeralVIII;
                break;
            case "VII":
                numeral = "VIII";
                left.sprite = numeralVII;
                center.sprite = numeralVIII;
                right.sprite = numeralIX;
                break;
            case "VIII":
                numeral = "IX";
                left.sprite = numeralVIII;
                center.sprite = numeralIX;
                right.sprite = numeralX;
                break;
            case "IX":
                numeral = "X";
                left.sprite = numeralIX;
                center.sprite = numeralX;
                right.sprite = numeralI;
                break;
            case "X":
                numeral = "I";
                left.sprite = numeralX;
                center.sprite = numeralI;
                right.sprite = numeralII;
                break;
        }
    }
}
