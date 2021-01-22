using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorkbenchDrawer : MonoBehaviour, IPointerClickHandler
{
    bool open;
    RectTransform orgPos;

    // Start is called before the first frame update
    void Start()
    {
        open = false;
        orgPos = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if ( Physics.Raycast(ray, out hit) )
            {
                if (hit.transform.name == "Workbench Inventory")
                {
                    Debug.Log("My object is clicked by mouse");
                }
            }
        }
        */
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!open)
        {
            LeanTween.moveY(gameObject, 0.01f, 0.1f).setDelay(0.1f);
            open = true;
        }
    }
    

}
