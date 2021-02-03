using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Inventory/Recipe", order = 2)]
public class CraftingRecipe : ScriptableObject
{
    public List<Item> Pieces;
    public Item result;
    public GameObject myButton;
    public int minItems;
    public bool notPuzzle;

    public bool CanCraft(IItemContainer container)
    {
        if (Pieces.Count >= minItems)
        {
            bool craft = false;
            foreach (Item item in Pieces)
            {
                if (container.ContainsItem(item))
                {
                    craft = true;
                }
                else
                {
                    craft = false;
                    return craft;
                }
            }
            return craft;
        }
        else
        {
            return false;
        }

    }
    public void Craft(IItemContainer container)
    {
        if (CanCraft(container))
        {
            if (notPuzzle)
            {
                List<Item> removed = new List<Item>();
                int itemsRemoved = 0;

                foreach (Item item in Pieces)
                {
                    if (container.RemoveItem(item))
                    {
                        removed.Add(item);
                        itemsRemoved++;
                    }
                }
                if (itemsRemoved != minItems)
                {
                    foreach (Item itm in removed)
                    {
                        container.AddItem(itm);
                    }
                }
                else
                {
                    container.AddItem(result);
                }
            }
            else
            {
                foreach (Item item in Pieces)
                {
                    container.RemoveItem(item);
                }
                myButton.SetActive(true);
            }
        }
    }
}
