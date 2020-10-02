using System.Collections;
using System.Diagnostics;
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
    { 2, 0, -2};
    // (top) 0, (Mid) 1, (bot) 2


    public int[] coinCue = new int[] { 1, 2, 3, 4 }; //tells a fuction what coin should be updated first

    public int[,] allCoinsPos = new int[3,4] // this store the current position of the coins in a 2d array for easy scanning //  this is being used on the cueCoinUpdate() function
    {
    {0, 0, 5, 0},
    {0, 0, 0, 0}, //this is very important add 5 to creat blocked space
    {1, 2, 3, 4}
    };

    /*
    {0, 0, 0, 5},
    {0, 5, 0, 0}, //this is very important add 5 to creat blocked space
    {1, 2, 3, 4}
     * 
     * solution 1
     * {0, 0, 2, 5}
     * {0, 5, 0, 1}
     * {0, 3, 0, 4}
     * solution 1 path
     * r,r,l,l,r,l,l,l,r,r,r,l,r,r,r
     * 
     * solution 2
     * {1, 4, 5, 0}
     * {3, 2, 0, 0}
     * {0, 0, 0, 0}
     * solution 2 path
     * r,r,r,r,l,r,r,r,r,r,l,r,r,r,r,r,r,r,r,l,l,l,r,r,r,r,l,l,r
     * 
     * 
     * 
     */
    //{Horizonta , Vertical}
    public int[] coin1Pos = new int[] { 0, 2 }; //first number is PositionH // second number is PoitionV
    public int[] coin2Pos = new int[] { 1, 2 };
    public int[] coin3Pos = new int[] { 2, 2 };
    public int[] coin4Pos = new int[] { 3, 2 };

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public GameObject blackaqr1;
    public GameObject blackaqr2;
    public GameObject blackaqr3;

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

            
            LeanTween.rotateZ(gameObject, table[tablePosition], 1); 
            
            //Add coins to a cue to be update
            coinCue = cueCoinUpdate();

            ManagePosition();
            
            //Debug.Log(allCoinsPos[0, 0]);

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

           ManagePosition();

        }

    }

 


    // float[] coinPositionH = new float[4] // left to right ( 0 , 1 , 2 , 3 )

    // float[] coinPositionV = new float[3] // top to bottom ( 0 , 1 , 2 )

    private float ManagePosition() // position
    {
        bool stop = false;
        int newLocation = 0;
        int nextLocation = newLocation + 1;
        //float newPosition;
        switch (tablePosition)
        {
            case 0: //H1  // for H1 we are moving PositionV only // the bounds is going up to the number "2"

                //I should check who should go first before anything
                for (int i = 0; i <= 3;  i++)
                {
                    
                    if (coinCue[i] == 1)
                    {
                        
                        //update coin1Pos and later allCoinsPos //// coin1Pos[1] is the PoitionV   
                        newLocation = coin1Pos[1];
                        nextLocation = newLocation + 1;

                        while (newLocation < 2)
                        {
                           
                            if (CheckIfOccupied(coin1Pos[0], nextLocation))
                            {
                                break;
                            }
                            
                            newLocation = nextLocation;
                            nextLocation++;

                        }
                        
                        //update the location at allCoinsPos[,] and at coin1Pos[]

                        allCoinsPos[coin1Pos[1], coin1Pos[0]] = 0; //take the coin out of her previous position

                        coin1Pos[1] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin1Pos[1], coin1Pos[0]] = 1;

                        //Move the coin to the new location
                        LeanTween.moveLocalY(coin1, coinPositionV[coin1Pos[1]],1);



                        newLocation = 0;
                        nextLocation = 0;
                    }
                    if (coinCue[i] == 2)
                    {
                        //update coin2 pos
                        newLocation = coin2Pos[1];
                        nextLocation = newLocation + 1;

                        while (newLocation < 2)
                        {

                            if (CheckIfOccupied(coin2Pos[0], nextLocation))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation++;

                        }


                        allCoinsPos[coin2Pos[1], coin2Pos[0]] = 0; //take the coin out of the previous position

                        coin2Pos[1] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin2Pos[1], coin2Pos[0]] = 2;

                        //Move the coin to the new location
                        LeanTween.moveLocalY(coin2, coinPositionV[coin2Pos[1]], 1);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 3)
                    {
                        //update coin3 pos
                        newLocation = coin3Pos[1];
                        nextLocation = newLocation + 1;

                        while (newLocation < 2)
                        {

                            if (CheckIfOccupied(coin3Pos[0], nextLocation))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation++;

                        }


                        allCoinsPos[coin3Pos[1], coin3Pos[0]] = 0; //take the coin out of the previous position

                        coin3Pos[1] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin3Pos[1], coin3Pos[0]] = 3;

                        //Move the coin to the new location
                        LeanTween.moveLocalY(coin3, coinPositionV[coin3Pos[1]], 1);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 4)
                    {
                        //update coin4 pos
                        newLocation = coin4Pos[1];
                        nextLocation = newLocation + 1;

                        while (newLocation < 2)
                        {

                            if (CheckIfOccupied(coin4Pos[0], nextLocation))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation++;

                        }


                        allCoinsPos[coin4Pos[1], coin4Pos[0]] = 0; //take the coin out of the previous position

                        coin4Pos[1] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin4Pos[1], coin4Pos[0]] = 4;

                        //Move the coin to the new location
                        LeanTween.moveLocalY(coin4, coinPositionV[coin4Pos[1]], 1);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                }
                


                break;
            case 1: //V1

                for (int i = 0; i <= 3; i++)
                {

                    if (coinCue[i] == 1)
                    {
                        //update coin1Pos and later allCoinsPos //// coin1Pos[1] is the PoitionH   
                        newLocation = coin1Pos[0];
                        nextLocation = newLocation - 1;

                        while (newLocation > 0)
                        {

                            if (CheckIfOccupied(nextLocation, coin1Pos[1]))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation--;

                        }

                        //update the location at allCoinsPos[,] and at coin1Pos[]

                        allCoinsPos[coin1Pos[1], coin1Pos[0]] = 0; //take the coin out of her previous position

                        coin1Pos[0] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin1Pos[1], coin1Pos[0]] = 1;

                        //Move the coin to the new location
                        LeanTween.moveLocalX(coin1, coinPositionH[coin1Pos[0]], 1);
                        UnityEngine.Debug.Log("LeanTween is called on " + coinPositionV[coin1Pos[1]]);


                        newLocation = 0;
                        nextLocation = 0;
                    }
                    if (coinCue[i] == 2)
                    {
                        //update coin2 pos
                        newLocation = coin2Pos[0];
                        nextLocation = newLocation - 1;

                        while (newLocation > 0)
                        {

                            if (CheckIfOccupied(nextLocation, coin2Pos[1]))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation--;

                        }

                        allCoinsPos[coin2Pos[1], coin2Pos[0]] = 0; //take the coin out of her previous position

                        coin2Pos[0] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin2Pos[1], coin2Pos[0]] = 2;

                        //Move the coin to the new location
                        LeanTween.moveLocalX(coin2, coinPositionH[coin2Pos[0]], 1);
                        UnityEngine.Debug.Log("LeanTween is called on " + coinPositionV[coin2Pos[1]]);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 3)
                    {
                        //update coin3 pos
                        newLocation = coin3Pos[0];
                        nextLocation = newLocation - 1;

                        while (newLocation > 0)
                        {

                            if (CheckIfOccupied(nextLocation, coin3Pos[1]))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation--;

                        }

                        allCoinsPos[coin3Pos[1], coin3Pos[0]] = 0; //take the coin out of her previous position

                        coin3Pos[0] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin3Pos[1], coin3Pos[0]] = 3;

                        //Move the coin to the new location
                        LeanTween.moveLocalX(coin3, coinPositionH[coin3Pos[0]], 1);
                        UnityEngine.Debug.Log("LeanTween is called on " + coinPositionV[coin3Pos[1]]);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 4)
                    {
                        //update coin4 pos
                        newLocation = coin4Pos[0];
                        nextLocation = newLocation - 1;

                        while (newLocation > 0)
                        {

                            if (CheckIfOccupied(nextLocation, coin4Pos[1]))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation--;

                        }

                        allCoinsPos[coin4Pos[1], coin4Pos[0]] = 0; //take the coin out of her previous position

                        coin4Pos[0] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin4Pos[1], coin4Pos[0]] = 4;

                        //Move the coin to the new location
                        LeanTween.moveLocalX(coin4, coinPositionH[coin4Pos[0]], 1);
                        UnityEngine.Debug.Log("LeanTween is called on " + coinPositionV[coin4Pos[1]]);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                }

                break;
            case 2: //H2
                //I should check who should go first before anything
                for (int i = 0; i <= 3; i++) // one of each coin starting from 0
                {
                    if (coinCue[i] == 1)
                    {
                        //update coin1Pos and later allCoinsPos //// coin1Pos[1] is the PoitionV   
                        newLocation = coin1Pos[1];
                        nextLocation = newLocation - 1;

                        while (newLocation > 0)
                        {

                            if (CheckIfOccupied(coin1Pos[0], nextLocation))
                            {
                                break;
                            }
                            newLocation = nextLocation;
                            nextLocation--;

                        }
                        
                        //update the location at allCoinsPos[,] and at coin1Pos[]

                        allCoinsPos[coin1Pos[1], coin1Pos[0]] = 0; //take the coin out of her previous position

                        coin1Pos[1] = newLocation; //update with new position

                        allCoinsPos[coin1Pos[1], coin1Pos[0]] = 1;

                        
                        //Move the coin to the new location

                        LeanTween.moveLocalY(coin1, coinPositionV[coin1Pos[1]], 1);
                        
                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 2)
                    {
                        //update coin2 pos
                        newLocation = coin2Pos[1];
                        nextLocation = newLocation - 1;

                        while (newLocation > 0)
                        {

                            if (CheckIfOccupied(coin2Pos[0], nextLocation))
                            {
                                break;
                            }
                            newLocation = nextLocation;
                            nextLocation--;

                        }

                        allCoinsPos[coin2Pos[1], coin2Pos[0]] = 0; //take the coin out of her previous position

                        coin2Pos[1] = newLocation; //update with new position

                        allCoinsPos[coin2Pos[1], coin2Pos[0]] = 2;


                        //Move the coin to the new location

                        LeanTween.moveLocalY(coin2, coinPositionV[coin2Pos[1]], 1);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 3)
                    {
                        //update coin3 pos
                        newLocation = coin3Pos[1];
                        nextLocation = newLocation - 1;

                        while (newLocation > 0)
                        {

                            if (CheckIfOccupied(coin3Pos[0], nextLocation))
                            {
                                break;
                            }
                            newLocation = nextLocation;
                            nextLocation--;

                        }

                        allCoinsPos[coin3Pos[1], coin3Pos[0]] = 0; //take the coin out of her previous position

                        coin3Pos[1] = newLocation; //update with new position

                        allCoinsPos[coin3Pos[1], coin3Pos[0]] = 3;


                        //Move the coin to the new location

                        LeanTween.moveLocalY(coin3, coinPositionV[coin3Pos[1]], 1);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 4)
                    {
                        //update coin4 pos
                        newLocation = coin4Pos[1];
                        nextLocation = newLocation - 1;

                        while (newLocation > 0)
                        {

                            if (CheckIfOccupied(coin4Pos[0], nextLocation))
                            {
                                break;
                            }
                            newLocation = nextLocation;
                            nextLocation--;

                        }

                        allCoinsPos[coin4Pos[1], coin4Pos[0]] = 0; //take the coin out of her previous position

                        coin4Pos[1] = newLocation; //update with new position

                        allCoinsPos[coin4Pos[1], coin4Pos[0]] = 4;


                        //Move the coin to the new location

                        LeanTween.moveLocalY(coin4, coinPositionV[coin4Pos[1]], 1);

                        newLocation = 0;
                        nextLocation = 0;

                    }
                }

                break;
            case 3: //V2


                for (int i = 0; i <= 3; i++)
                {

                    if (coinCue[i] == 1)
                    {
                        newLocation = coin1Pos[0];
                        nextLocation = newLocation + 1;

                        while (newLocation < 3)
                        {

                            if (CheckIfOccupied(nextLocation, coin1Pos[1]))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation++;
                            UnityEngine.Debug.Log(newLocation + "   this is newLocation LATER");
                        }

                        //update the location at allCoinsPos[,] and at coin1Pos[]

                        allCoinsPos[coin1Pos[1], coin1Pos[0]] = 0; //take the coin out of her previous position

                        coin1Pos[0] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin1Pos[1], coin1Pos[0]] = 1;

                        //Move the coin to the new location
                        LeanTween.moveLocalX(coin1, coinPositionH[coin1Pos[0]], 1);
                        UnityEngine.Debug.Log("LeanTween is called on " + coinPositionV[coin1Pos[1]]);


                        newLocation = 0;
                        nextLocation = 0;
                    }
                    if (coinCue[i] == 2)
                    {
                        //update coin2 pos
                        newLocation = coin2Pos[0];
                        nextLocation = newLocation + 1;

                        while (newLocation < 3)
                        {

                            if (CheckIfOccupied(nextLocation, coin2Pos[1]))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation++;
                            UnityEngine.Debug.Log(newLocation + "   this is newLocation LATER");
                        }

                        allCoinsPos[coin2Pos[1], coin2Pos[0]] = 0; //take the coin out of her previous position

                        coin2Pos[0] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin2Pos[1], coin2Pos[0]] = 2;

                        //Move the coin to the new location
                        LeanTween.moveLocalX(coin2, coinPositionH[coin2Pos[0]], 1);
                        UnityEngine.Debug.Log("LeanTween is called on " + coinPositionV[coin2Pos[1]]);


                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 3)
                    {
                        //update coin3 pos
                        newLocation = coin3Pos[0];
                        nextLocation = newLocation + 1;

                        while (newLocation < 3)
                        {

                            if (CheckIfOccupied(nextLocation, coin3Pos[1]))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation++;
                            UnityEngine.Debug.Log(newLocation + "   this is newLocation LATER");
                        }

                        allCoinsPos[coin3Pos[1], coin3Pos[0]] = 0; //take the coin out of her previous position

                        coin3Pos[0] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin3Pos[1], coin3Pos[0]] = 3;

                        //Move the coin to the new location
                        LeanTween.moveLocalX(coin3, coinPositionH[coin3Pos[0]], 1);
                        UnityEngine.Debug.Log("LeanTween is called on " + coinPositionV[coin3Pos[1]]);


                        newLocation = 0;
                        nextLocation = 0;

                    }
                    if (coinCue[i] == 4)
                    {
                        //update coin4 pos
                        newLocation = coin4Pos[0];
                        nextLocation = newLocation + 1;

                        while (newLocation < 3)
                        {

                            if (CheckIfOccupied(nextLocation, coin4Pos[1]))
                            {
                                break;
                            }

                            newLocation = nextLocation;
                            nextLocation++;
                            UnityEngine.Debug.Log(newLocation + "   this is newLocation LATER");
                        }

                        allCoinsPos[coin4Pos[1], coin4Pos[0]] = 0; //take the coin out of her previous position

                        coin4Pos[0] = newLocation; //update with new position

                        //Debug.Log("it's working here");
                        allCoinsPos[coin4Pos[1], coin4Pos[0]] = 4;

                        //Move the coin to the new location
                        LeanTween.moveLocalX(coin4, coinPositionH[coin4Pos[0]], 1);
                        UnityEngine.Debug.Log("LeanTween is called on " + coinPositionV[coin4Pos[1]]);


                        newLocation = 0;
                        nextLocation = 0;

                    }
                }


                break;
            default:
                UnityEngine.Debug.Log("The tablePosition is out of bounds");
                break;
        }
        return 0;
    }


    private bool CheckIfOccupied(int HorizontalPos, int VerticalPos)
    {
        UnityEngine.Debug.Log(VerticalPos + "  this is V");
        UnityEngine.Debug.Log(HorizontalPos + "   this is H");
        if (allCoinsPos[VerticalPos, HorizontalPos] == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }

    
    //down here is working fine

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
                        if (allCoinsPos[i, j] != 0 && allCoinsPos[i, j] != 5)
                        {
                            order[orderCue] = allCoinsPos[i, j];
                            orderCue++;
                        }
                    }

                }

                break;
            case 1: // this is Vertical 1

                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {
                        if (allCoinsPos[j, i] != 0 && allCoinsPos[j, i] != 5)
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
                        if (allCoinsPos[i, j] != 0 && allCoinsPos[i, j] != 5)
                        {
                            order[orderCue] = allCoinsPos[i, j];
                            orderCue++;
                        }
                    }


                }


                break;
            case 3: // this is Vertical 2
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 0; j <= 2; j++)
                    {

                        if (allCoinsPos[j, i] != 0 && allCoinsPos[j, i] != 5)
                        {
                            order[orderCue] = allCoinsPos[j, i];
                            orderCue++;
                        }

                    }

                }

                break;
            default:
                UnityEngine.Debug.Log("The tablePosition is out of bounds");
                break;
        }

        /*order[0] = 1;
        order[1] = 2;
        order[2] = 3;   //this is for Debug
        order[3] = 4;*/
        return order;

    }

    /*public int[,] allCoinsPos = new int[3, 4]
    {
    {0, 0, 0, 0},  03
    {0, 0, 0, 0},  13
    {1, 2, 3, 4}   23
    };*/
    private bool checkAnswer(int[,]allCoinsPos, int[,] answer) // work in progress
    {
        for(int i=0; i <= 3; i++)
        {
            for (int j = 0; j <= 3; j++)
            {

            }
        }
        return false;
    }

}
