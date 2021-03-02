using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingHolder : MonoBehaviour
{
    //Data class for holding an instance of the drawing board. 

    public List<DrawPoint> leftLeft;
    public List<DrawPoint> midLeft;
    public List<DrawPoint> mid;
    public List<DrawPoint> midRight;
    public List<DrawPoint> rightRight;

    public void ClearConnections()
    {
        //Run through each list, grab each point, and clear it
        foreach(DrawPoint point in leftLeft)
        {
            point.connections.Clear();
        }
        foreach (DrawPoint point in midLeft)
        {
            point.connections.Clear();
        }
        foreach (DrawPoint point in mid)
        {
            point.connections.Clear();
        }
        foreach (DrawPoint point in midRight)
        {
            point.connections.Clear();
        }
        foreach (DrawPoint point in rightRight)
        {
            point.connections.Clear();
        }
    }
}
