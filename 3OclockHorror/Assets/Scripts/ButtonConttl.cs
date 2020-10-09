using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConttl : MonoBehaviour
{
    public CraftingRecipe myRecipie;
    // Start is called before the first frame update
    void Start()
    {
        myRecipie.myButton = this.gameObject;
        this.gameObject.SetActive(false);
    }
}
