using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LPhotoCntrl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item myPhoto;
    public Image me;
    PicSlot currentSlot = null;
    [SerializeField]
    Sprite back;
    [SerializeField]
    Text date;
    [SerializeField]
    Text numeral;
    [SerializeField]
    PicSlot[] pictureSlots;
    public bool interactable = true;

    // Start is called before the first frame update
    void Start()
    {
        if (myPhoto != null)
        {
            me.sprite = myPhoto.Icon;
            date.text = myPhoto.date;
            numeral.text = myPhoto.numeral;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitLargePhoto(Item photo)
    {
        myPhoto = photo;
        me.sprite = myPhoto.Icon;
        date.text = myPhoto.date;
        numeral.text = myPhoto.numeral;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            if(currentSlot != null)
            {
                if(currentSlot.photo != null)
                {
                    currentSlot.photo = null;
                    currentSlot = null;
                }
            }
            transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
            transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            GetClosestObject(this, pictureSlots);
        }
    }

    void GetClosestObject(LPhotoCntrl target, PicSlot[] objects)
    {
        PicSlot closestObject = null;
        float closestDist = Mathf.Infinity;
        Vector3 Position = target.transform.position;

        foreach (PicSlot obj in objects)
        {
            Vector3 directionToTarget = obj.transform.position - Position;
            float distanceToTarget = directionToTarget.sqrMagnitude;

            if (distanceToTarget < closestDist)
            {
                closestObject = obj;
                closestDist = distanceToTarget;
            }
        }

        if (closestObject.photo == null)
        {
            closestObject.photo = target;
            currentSlot = closestObject;
            target.transform.position = closestObject.transform.position;
        }
    }
}
