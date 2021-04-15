using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LPhotoCntrl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item myPhoto;
    public Image me;
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
            transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;
            transform.SetAsLastSibling();
            for (int i = 0; i < pictureSlots.Length; i++)
            {
                pictureSlots[i].selectedPhoto = this;
                pictureSlots[i].pointerData = eventData;
            }
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
        /*GetClosestObject(this.gameObject, pictureSlots);*/
    }

    void GetClosestObject(GameObject target, PicSlot[] objects)
    {
        int closestObject = 0;
        int j = 0;
        float closestDist = Mathf.Infinity;
        Vector3 Position = target.transform.position;

        foreach (PicSlot obj in objects)
        {
            Vector3 directionToTarget = obj.transform.position - Position;
            float distanceToTarget = directionToTarget.sqrMagnitude;

            if (distanceToTarget < closestDist)
            {
                closestObject = j;
                closestDist = distanceToTarget;
            }

            j++;
        }

        target.transform.position = objects[j].transform.position;
    }
}
