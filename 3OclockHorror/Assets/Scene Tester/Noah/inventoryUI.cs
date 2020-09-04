using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    inventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += updateUI;

        slots = itemsParent.GetComponentsInChildren<inventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].addItem(inventory.items[i]);
            }
        }
    }
}
