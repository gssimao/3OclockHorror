using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LPhotoCntrl : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Item myPhoto;
    [SerializeField]
    Image me;
    [SerializeField]
    Sprite back;
    [SerializeField]
    Text date;
    [SerializeField]
    Text numeral;
    [SerializeField]
    PicSlot[] pictureSlots;

    bool isFlipped;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipped)
        {
            me.sprite = back;
            date.gameObject.SetActive(true);
            numeral.gameObject.SetActive(true);
        }
        else
        {
            me.sprite = myPhoto.Icon;
            date.gameObject.SetActive(false);
            numeral.gameObject.SetActive(false);
        }
    }

    public void InitLargePhoto(Item photo)
    {
        myPhoto = photo;
        me.sprite = myPhoto.Icon;
        date.text = myPhoto.date;
        numeral.text = myPhoto.numeral;
    }

    public void Flip()
    {
        if (isFlipped)
        {
            isFlipped = false;
        }
        else
        {
            isFlipped = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
        transform.SetAsLastSibling();
        for(int i = 0; i < pictureSlots.Length; i++)
        {
            pictureSlots[i].selectedPhoto = this.gameObject;
            pictureSlots[i].pointerData = eventData;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
    }
}
