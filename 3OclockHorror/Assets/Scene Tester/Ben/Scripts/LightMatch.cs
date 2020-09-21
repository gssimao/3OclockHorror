using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMatch : MonoBehaviour
{

    public GameObject Match;

    // Start is called before the first frame update
    void Start()
    {
        Match = new GameObject("Match", typeof(Light));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Instantiate(Match, this.transform.position, this.transform.rotation);
        }
        Destroy(Match, 5.0f);
    }
}
