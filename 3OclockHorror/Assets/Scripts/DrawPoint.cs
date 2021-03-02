using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawPoint : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    drawingPuzzle PuzzleCntrl;
    public List<GameObject> connections; //Updated when a line is drawn from here

    Image sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(PuzzleCntrl.getSelected() == null)
            {
                PuzzleCntrl.setSelected(gameObject);
                PuzzleCntrl.setSR(sr);
            }
            else
            {
                PuzzleCntrl.DrawLine(gameObject);
            }
        }
    }   
}
