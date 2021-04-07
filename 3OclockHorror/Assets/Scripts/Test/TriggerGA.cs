using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGA : MonoBehaviour
{
    public List<GameAction> actions;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameAction item in actions)
            item.Action();
    }
}
