using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullEnd : MonoBehaviour
{
    [SerializeField]
    TaskListTracker taskManager;
    [Space]
    [SerializeField]
    SpriteRenderer LibSprite;
    [SerializeField]
    Sprite newLib;
    [Space]
    [SerializeField]
    GameObject Necklace;

    public void OpenLeftEnding()
    {
        taskManager.updateList("Some sort of noise eminated from the Library - What could it be?");
        LibSprite.sprite = newLib;
        Necklace.SetActive(true);
    }
}
