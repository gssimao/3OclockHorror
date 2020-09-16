using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class dragDown : MonoBehaviour
{
    public float Speed;
    public float angularSpeed;
    protected Rigidbody Coin;
    public bool freeze = false;
    public GameObject Table;
    int[] positionBank = new int[] { 0, 90, 180, 270};
    public int currentPositionZ = 0;


    void Start()
    {
        Coin = GetComponent<Rigidbody>();
    }

    void pullDown()
    {
        Speed = Coin.velocity.magnitude;
        angularSpeed = Coin.angularVelocity.magnitude;

        Coin.AddForce(Vector3.down);
    }

    void turnTable()
    {
        
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("click");
            currentPositionZ++;
                if(currentPositionZ >3)
                {
                     currentPositionZ = 0;
                }

            LeanTween.rotateZ(Table, positionBank[currentPositionZ], 1);

        }
    }

    void Update()
    {
        if (freeze == false)
       {
            pullDown();
       }

    }
}
