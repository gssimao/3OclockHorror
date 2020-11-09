using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalSlotCntrl : MonoBehaviour
{
    [SerializeField]
    ItemSlot pSlot;
    [SerializeField]
    Text myText;
    [SerializeField]
    Image myImage;

    // Start is called before the first frame update
    void Start()
    {
        //Check that parent slot is not null
        if(pSlot == null)
        {
            Debug.Log("No parent slot assigned for " + this.gameObject.name);
        }
    }
    void Update()
    {
        if(pSlot.Item != null)
        {
            myImage.sprite = pSlot.Item.Icon;
            myText.text = pSlot.Item.desc;
        }
    }
}
