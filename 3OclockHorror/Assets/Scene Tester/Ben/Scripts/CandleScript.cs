using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    public GameObject Light;
    Light flame; //Variable to that holds the light component of the game object

    public float interactableRange;

    // Start is called before the first frame update
    void Start()
    {
        flame = Light.GetComponent<Light>(); //gets the light component of the child of this game object and sets it to the variable
        interactableRange = flame.range / flame.range + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()// Draws a blue circle around the candle in the editor to help visualize the disance of the interactableRange
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position, interactableRange);
    }

    void OnTriggerStay(Collider other)
    {
        float temp;

        if(other.tag == "Player")
        {
            temp = DistanceFunction(other.transform.position, gameObject.transform.position);

            if(temp <= interactableRange && Input.GetKeyDown("e"))
            {
                if(Light.activeSelf)
                {
                    Light.SetActive(false);
                }
                else
                {
                    Light.SetActive(true);
                }
            }
        }
        if(other.tag == "Blind Creep")
        {

        }
    }

    float DistanceFunction(Vector3 A, Vector3 B)// The iconic distance formula but for three coordinates
    {
        float ans, x, y, z;

        x = Mathf.Pow(A.x - B.x, 2);
        y = Mathf.Pow(A.y - B.y, 2);
        z = Mathf.Pow(A.z - B.z, 2);

        ans = Mathf.Sqrt(x + y + z);

        return ans;
    }
}
