using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicSlot : MonoBehaviour
{
    public GameObject selectedPhoto;

    public float lockRange;

    float dist;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, selectedPhoto.transform.position);

        if(dist == lockRange)
        {
            selectedPhoto.transform.position = this.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, lockRange);
    }
}
