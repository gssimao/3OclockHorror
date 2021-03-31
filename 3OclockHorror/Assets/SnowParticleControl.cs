using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowParticleControl : MonoBehaviour
{
    public GameObject Player;
    public room LocalRoom;
    public ParticleSystem SnowParticle;
    public ParticleSystem [] SnowParticleArray;
    

   /* private void FixedUpdate() // this is a test to see if the code is working (and it is)
    {
        ActivateSnowParticle(); 
    }*/
 /*   void ActivateSnowParticle() //this will check if the player is in the same room as the particle effect and if so it will turn the effect on
    {
        PlayerMovement player = Player.GetComponent<PlayerMovement>(); //Grab player movement script
        if (player.myRoom.roomName == LocalRoom.roomName)
        {
            SnowParticle.Play();
        }
        else
        {
            SnowParticle.Pause();
        }
    }*/
}
