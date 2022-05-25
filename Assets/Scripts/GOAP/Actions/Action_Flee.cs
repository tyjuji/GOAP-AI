using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Flee : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Attack) });

    GameObject destination;

    public override bool CanRun()
    {
        return true;
    }

    public override float GetCost()
    {
        return (lifeHandler.Health / lifeHandler.startingHealth * 100f) + 30f - los.dangerFactor;
    }

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        destination = lifeHandler.FindFurthestFromPlayer(lifeHandler.retreats);
        navMeshAgent.SetDestination(destination.transform.position);

        navMeshAgent.updateRotation = true;
        navMeshAgent.updatePosition = true;
        navMeshAgent.isStopped = false;

        base.OnActivated(_linkedGoal);
    }

    public override void OnDeactivated()
    {
        base.OnDeactivated();
    }

    public override void OnTick()
    {
        destination = lifeHandler.FindFurthestFromPlayer(lifeHandler.retreats);
        navMeshAgent.SetDestination(destination.transform.position);

        if (los.CanSeePlayer)
        {
            transform.LookAt(player.transform.position);
            lifeHandler.Shoot();
        }

        navMeshAgent.Move(Vector3.zero);
    }
}
