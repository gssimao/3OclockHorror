using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class TableManager : MonoBehaviour
{

    int[] table = new int[] { 0, 90, 180, 270 };
    public int tablePosition = 0;

    float[] coinPositionH = new float[4] // left to right  // This is a number refering to a position in the game where any coin can be placed at
    {-5, -2, 2, 5};
    //    0,  1,  2, 3
    // 0 is most left and 3 is most right

    float[] coinPositionV = new float[3] // top to bottom  // This is a number refering to a position in the game where any coin can be placed at
    { 3, 0, -3};
    // (top) 0, (Mid) 1, (bot) 2


    public int[] coinCue = new int[] { 1, 2, 3, 4 }; //tells a fuction what coin should be updated first

    public int[,] allCoinsPos = new int[3,4] // this store the current position of the coins in a 2d array for easy scanning //  this is being used on the cueCoinUpdate() function
    {
    {0, 0, 0, 0},
    {0, 0, 0, 0},
    {1, 2, 3, 4}
    };
                      //{Horizonta , Vertical}
    public int[] coin1Pos = new int[] { 0, 2 }; //first number is PositionH // second number is PoitionV
    public int[] coin2Pos = new int[] { 1, 2 };
    public int[] coin3Pos = new int[] { 2, 2 };
    public int[] coin4Pos = new int[] { 3, 2 };
    public bool coin1Updated = true;
    public bool coin2Updated = true;
    public bool coin3Updated = true;
    public bool coin4Updated = true;

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;

    private void Start()
    {
        coin1.transform.position = new Vector3(coinPositionH[coin1Pos[0]], coinPositionV[coin1Pos[1]], -2); // coinPositionH and coinPositionV are just numbers 
        coin2.transform.position = new Vector3(coinPositionH[coin2Pos[0]], coinPositionV[coin2Pos[1]], -2); //      to where to coins are going to be placed on
        coin3.transform.position = new Vector3(coinPositionH[coin3Pos[0]], coinPositionV[coin3Pos[1]], -2);
        coin4.transform.position = new Vector3(coinPositionH[coin4Pos[0]], coinPositionV[coin4Pos[1]], -2);// coin4Pos keeps track of coin Number 4 position
    }


    private void OnMouseOver()
    {

        if (Input.GetMouseButtonUp(0)) //this should turn the big to the left
        {
            tablePosition++;
            if (tablePosition > 3)
            {
                tablePosition = 0;
            }
           
            LeanTween.rotateZ(gameObject, table[tablePosition], 1); // move big gear
            
            //Add coins to a cue to be update
            coinCue = cueCoinUpdate();



        }
        if (Input.GetMouseButtonUp(1)) //this should turn the big to the right
        {
            tablePosition--;
            if (tablePosition < 0)
            {
                tablePosition = 3;
            }
            
            LeanTween.rotateZ(gameObject, table[tablePosition], 1); // move big gear
            
            //Add coins to a cue to be update
            coinCue = cueCoinUpdate();




        }


    }

 


    // float[] coinPositionH = new float[4] // left to right ( 0 , 1 , 2 , 3 )

    // float[] coinPositionV = new float[3] // top to bottom ( 0 , 1 , 2 )

    private float ManagePosition(int tablePosition, int[] coinPos) // position
    {
        //float newPosition;
        switch (tablePosition)
        {
            case 0: // this is Horizontal 1: ONLY MOVING HORIZONTAL   // coinPositionV ADDING one and stoping at 2

                break;
            case 1: // this is Vertical 1: ONLY MOVING VERTICAL  // coinPositionH ADDING one and stoping at 3
                //I should check who should go first before anything


                break;
            case 2: // this is Horizontal 2: ONLY MOVING HORIZONTAL BUT BACKWARDS   // coinPositionV SUBTRACTING one and stoping at 0

                break;
            case 3: // this is Vertical 2: ONLY MOVING VERTICAL BUT BACKWARDS // coinPositionH SUBTRACTING one and stoping at 0

                break;
            default:
                Debug.Log("The tablePosition is out of bounds");
                break;
        }
        return 0;
    }

    private int[] cueCoinUpdate()
    {
        int[] order = new int[] {0,0,0,0};
        int orderCue = 0;
        switch (tablePosition)
        {
            case 0: // this is Horizontal 1

                for (int i = 2; i >= 0; i--)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        if (allCoinsPos[j, i] != 0)
                        {
                            order[orderCue] = allCoinsPos[j, i];
                            orderCue++;
                            /*if (orderCue == 3)
                            {
                                break;
                            }*/
                                
                        }
                    }
                }

                break;
            case 1: // this is Vertical 1
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (allCoinsPos[j, i] != 0)
                        {
                            order[orderCue] = allCoinsPos[j, i];
                            orderCue++;
                        }
                    }
                }
                break;
            case 2: // this is Horizontal 2
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        if (allCoinsPos[j, i] != 0)
                        {
                            order[orderCue] = allCoinsPos[j, i];
                            orderCue++;
                            /*if (orderCue == 3)
                            {
                                break;
                            }*/

                        }
                    }
                }


                break;
            case 3: // this is Vertical 2
                
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (allCoinsPos[j, i] != 0)
                        {
                            order[orderCue] = allCoinsPos[j, i];
                            orderCue++;
                            /*if (orderCue == 3)
                            {
                                break;
                            }*/
                        }
                    }
                }
                break;
            default:
                Debug.Log("The tablePosition is out of bounds");
                break;
        }
        return order;
    }

    /*public int[,] allCoinsPos = new int[3, 4]
    {
    {0, 0, 0, 0},  03
    {0, 0, 0, 0},  13
    {1, 2, 3, 4}   23
    };*/




  private void updateCoinLocation()
  {
      int current;
      int comparing;

      switch (tablePosition)
      {
          case 0: // this is Horizontal 1: ONLY MOVING HORIZONTAL  
              
              break;
          case 1: // this is Vertical 1: ONLY MOVING VERTICAL 

              break;
          case 2: // this is Horizontal 2: ONLY MOVING HORIZONTAL BUT BACKWARDS   

              break;
          case 3: // this is Vertical 2: ONLY MOVING VERTICAL BUT BACKWARDS 

              break;
          default:
              Debug.Log("The tablePosition is out of bounds");
              break;
      }



      //return start;
  }






}
