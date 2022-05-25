using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action_MoveToPlayer : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(
        new System.Type[] { typeof(Goal_Attack) });

    //float firstSeen = 0f;
    //private float lastSeen = 0f;

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override bool CanRun()
    {
        return !los.CanSeePlayer;
    }

    public override float GetCost()
    {
        //return 1 / (lifeHandler.startingHealth / lifeHandler.Health * 100f);
        //return lifeHandler.Health / lifeHandler.startingHealth * 100f;
        return (lifeHandler.startingHealth - lifeHandler.Health) / lifeHandler.startingHealth * 100;
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.updateRotation = true;
        navMeshAgent.updatePosition = true;
        navMeshAgent.isStopped = false;

        base.OnActivated(_linkedGoal);
    }

    public override void OnDeactivated()
    {
        navMeshAgent.SetDestination(gameObject.transform.position);

        base.OnDeactivated();
    }

    public override void OnTick()
    {
        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.Move(Vector3.zero);
    }
}
