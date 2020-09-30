using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipieHolder : MonoBehaviour
{

    [SerializeField]
    List<CraftingRecipe> Recipies;
    [SerializeField]
    Inventory craftInv;

    public void Craft()
    {
        foreach(CraftingRecipe recipe in Recipies)
        {
            if (recipe.CanCraft(craftInv))
            {
                recipe.Craft(craftInv);
            }
        }
    }
}
