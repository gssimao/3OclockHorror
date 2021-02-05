using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
    public float lifeTime;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        this.transform.position = player.transform.position;

        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
