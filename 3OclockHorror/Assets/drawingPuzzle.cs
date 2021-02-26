using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawingPuzzle : MonoBehaviour
{
    GameObject selected = null; //Storage for the selected point and it's image renderer
    Image sr = null;

    [SerializeField]
    GameObject LineParent; //The storage for all lines
    [SerializeField]
    GameObject lineConnection; //The actual prefab line

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selected != null) //If the mouse is right clicked and there is a selected point, deselect it
        {
            resetSelection();
        }

        if(sr != null)
        {
            sr.color = Color.red; //Show the selected point, if any, in a special color.
        }
    }

    #region Selected Get/Set
    public GameObject getSelected()
    {
        return selected;
    }
    public void setSelected(GameObject newObj)
    {
        selected = newObj;
    }
    public void setSR(Image newImg)
    {
        sr = newImg;
    }
    #endregion

    #region Drawing Lines
    //Draw a line when one point is selected and another is clicked
    public void DrawLine(GameObject obj2)
    {
        /*
        LineRenderer lr = LineParent.AddComponent<LineRenderer>();
        List<Vector3> pos = new List<Vector3>();
        pos.Add(genVec3Pos(selected));
        pos.Add(genVec3Pos(obj2));
        lr.startWidth = 1f;
        lr.endWidth = 1f;
        lr.SetPositions(pos.ToArray());
        lr.useWorldSpace = true;
        lr.renderingLayerMask = 9;
        */

        createALine(selected, obj2);
        resetSelection();
    }

    //Grab the line prefab and create a long / thin one between two points
    private void createALine(GameObject objA, GameObject objB)
    {
        /*spawn a prefab image "lineConnection" as angleBar*/
        GameObject angleBar = Instantiate(lineConnection, objB.transform.position, Quaternion.identity);
        /**/
        /*calculate angle*/
        Vector2 diference = objA.transform.position - objB.transform.position;
        float sign = (objA.transform.position.y < objB.transform.position.y) ? -1.0f : 1.0f;
        float angle = Vector2.Angle(Vector2.right, diference) * sign;
        angleBar.transform.Rotate(0, 0, angle);
        /**/
        /*calculate length of bar*/
        float height = 5;
        float width = Vector2.Distance(objB.transform.position, objA.transform.position);
        angleBar.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        /**/
        /*calculate midpoint position*/
        float newposX = objB.transform.position.x + (objA.transform.position.x - objB.transform.position.x) / 2;
        float newposY = objB.transform.position.y + (objA.transform.position.y - objB.transform.position.y) / 2;
        angleBar.transform.position = new Vector3(newposX, newposY, 0);
        /***/
        /*set parent to objB*/
        angleBar.transform.SetParent(LineParent.transform, true);
    }

    /*
    public Vector3 genVec3Pos(GameObject obj)
    {
        return new Vector3(obj.transform.position.x, obj.transform.position.y, -0.01f);
    }
    */

    //Reset the selected point's image, so that the point isn't selected and it's image isn't red anymore.
    public void resetSelection()
    {
        selected = null;
        if (sr != null)
        {
            sr.color = Color.white;
            sr = null;
        }
    }
    #endregion

    //Resets the lines
    public void Reset()
    {
        foreach (Transform child in LineParent.transform)
        {
            Destroy(child.gameObject);
        }
        resetSelection();
    }
    //Checks the answer
    public void checkAnswer()
    {

    }
}
