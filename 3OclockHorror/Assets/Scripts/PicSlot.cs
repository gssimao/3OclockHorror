using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PicSlot : MonoBehaviour
{
    public LPhotoCntrl selectedPhoto;
    public PointerEventData pointerData;

    public float lockRange;
    public float dist;
    float dist2;

    public LPhotoCntrl photoinSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedPhoto != null)
        {
            dist = Vector3.Distance(this.transform.position, selectedPhoto.transform.position);
            if (dist <= lockRange)
            {
                if (!pointerData.dragging)
                {
                    selectedPhoto.transform.position = this.transform.position;
                    photoinSlot = selectedPhoto;
                }
            }
        }

        if (photoinSlot != null)
        {
            dist2 = Vector3.Distance(this.transform.position, photoinSlot.transform.position);
            if (dist2 > lockRange)
            {
                photoinSlot = null;
            }
            else if (photoinSlot != null && !pointerData.dragging)
            {
                photoinSlot.transform.position = this.transform.position;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, lockRange);
    }
}
