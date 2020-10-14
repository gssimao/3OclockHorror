using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Inventory/Recipe", order = 2)]
public class CraftingRecipe : ScriptableObject
{
    public List<Item> Pieces;
    public GameObject myButton;

    public bool CanCraft(IItemContainer container)
    {
        bool craft = false;
        foreach(Item item in Pieces)
        {
            if (container.ContainsItem(item))
            {
                craft = true;
            }
            else
            {
                craft = false;
            }
        }
        return craft;
    }
    public void Craft(IItemContainer container)
    {
        if (CanCraft(container))
        {
            foreach(Item item in Pieces)
            {
                container.RemoveItem(item);
            }
            myButton.SetActive(true);
        }
    }
}
