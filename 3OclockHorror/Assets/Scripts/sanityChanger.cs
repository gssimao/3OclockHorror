using UnityEngine;

public class sanityChanger : MonoBehaviour //Changes asset of parent game object based on player's sanity
{
    [SerializeField]
    SanityManager player; //Hold the player's sanity manager
    [SerializeField]
    float sanityThreshold; //The threshold to trigger the change
    [SerializeField]
    SpriteRenderer sr; //Sprite Renderer for the gameobject
    [SerializeField]
    Sprite saneSprite; //Sprite for above threshold
    [SerializeField]
    Sprite insaneSprite; //Sprite for below threshold 

    // Update is called once per frame
    void Update()
    {
        if(player.sanityValue < sanityThreshold)
        {
            sr.sprite = insaneSprite;
        }
        else
        {
            sr.sprite = saneSprite;   
        }
    }
}
