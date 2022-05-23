using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action_Attack : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(
            new System.Type[] { typeof(Goal_Attack) });

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override bool CanRun()
    {
        return los.CanSeePlayer;
    }


    public override float GetCost()
    {
        return lifeHandler.Health / lifeHandler.startingHealth * 100f;
    }

    public override void OnTick()
    {
        navMeshAgent.isStopped = true;
        transform.LookAt(player.transform.position);
        lifeHandler.Shoot();
    }
}

