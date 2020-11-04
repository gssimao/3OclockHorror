using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvSlotTextController : MonoBehaviour
{
    [SerializeField]
    Text[] slotBoxes;
    [SerializeField]
    ItemSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        if(slotBoxes == null || slots == null)
        {
            Debug.LogError("Both the list of text boxes and the list of slots must be filled out");
        }
        if(slots.Length != slotBoxes.Length)
        {
            Debug.LogError("Slots and SlotBoxes must have the same length");
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < slotBoxes.Length; i++)
        {
            if(slots[i] != null && slots[i].Item == null)
            {
                slotBoxes[i].text = " ";
            }
            else if(slots[i] != null && slots[i].Item != null)
            {
                slotBoxes[i].text = slots[i].Item.desc;
            }
        }
    }
}
