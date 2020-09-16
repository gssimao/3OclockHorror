using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatrolState", menuName = "Unity-FSM/States/Patrol", order = 2)]
public class patrolState : abstractFSMState
{
    //NPCPatrolPoint[] patrolpoints;
    int patrolPoinrIndex;

    public override void OnEnable()
    {
        base.OnEnable();
        patrolPoinrIndex = -1;
    }
    public override bool enterState()
    {
        if(base.enterState())
        {
            //grab and store points

        }
        return base.enterState();
    }

    public override void updateState()
    {
        throw new System.NotImplementedException();
    }
}
