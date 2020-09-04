using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventoy/Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public Sprite sprite; //The sprite of the item for the inventory.
    public GameObject itemObject; //The actual item associated with the inventory item. 
    public string description; //Description tag, primarily for journal entry.
    public int lvl; //Tag associated with level for placement reasons.
    public bool rand; //Can this item be randomized?
}
