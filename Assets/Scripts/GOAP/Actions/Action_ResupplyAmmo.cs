using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_ResupplyAmmo : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Resupply) });


    GameObject destination;

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override bool CanRun()
    {
        return lifeHandler.AmmoAvailable;
    }

    public override float GetCost()
    {
        return lifeHandler.Ammo / lifeHandler.startingAmmo;
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        destination = lifeHandler.FindNearestActive(lifeHandler.ammoPickups);
        navMeshAgent.SetDestination(destination.transform.position);

        Debug.Log(destination);

        navMeshAgent.updatePosition = true;
        navMeshAgent.updateRotation = true;
        navMeshAgent.isStopped = false;


        base.OnActivated(_linkedGoal);
    }

    public override void OnDeactivated()
    {
        base.OnDeactivated();
    }

    public override void OnTick()
    {
        if (destination == null)
        {
            destination = lifeHandler.FindNearestActive(lifeHandler.ammoPickups);
            navMeshAgent.SetDestination(destination.transform.position);
        }

        if (los.CanSeePlayer)
        {
            lifeHandler.ShieldOn();
        }

        Debug.Log(destination);

        navMeshAgent.Move(Vector3.zero);
    }
}
