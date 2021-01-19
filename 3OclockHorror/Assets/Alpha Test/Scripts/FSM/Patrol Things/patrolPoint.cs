using System.Collections;
using UnityEngine;

public class patrolPoint : MonoBehaviour
{
    [SerializeField]
    protected float debugDrawRadius = 1.0f;
    [SerializeField]
    bool drawDebug;

    public virtual void OnDrawGizmos()
    {
        if (drawDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
        }
    }
}
