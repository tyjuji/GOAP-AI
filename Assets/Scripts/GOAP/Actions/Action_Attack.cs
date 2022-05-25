using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action_Attack : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(
            new System.Type[] { typeof(Goal_Attack) });

    float firstSeen = 0f;
    private float lastSeen = 0f;

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
        //return lifeHandler.Health / lifeHandler.startingHealth * 100f;
        return (lifeHandler.startingHealth - lifeHandler.Health) / lifeHandler.startingHealth * 100;
        //if (lastSeen + 5f < Time.time)
        //{
        //    return 0;
        //}
        //return Time.time - firstSeen;
    }

    public override void OnTick()
    {
        navMeshAgent.isStopped = true;
        transform.LookAt(player.transform.position);
        lifeHandler.Shoot();
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        firstSeen = Time.time;

        base.OnActivated(_linkedGoal);
    }

    public override void OnDeactivated()
    {
        lastSeen = Time.time;
        base.OnDeactivated();
    }
}

