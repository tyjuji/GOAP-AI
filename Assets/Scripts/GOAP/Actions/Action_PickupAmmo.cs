using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_PickupAmmo : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Resupply) });

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override bool CanRun()
    {
        return lifeHandler.Ammo < lifeHandler.startingAmmo - 5;

    }

    public override float GetCost()
    {
        return lifeHandler.Ammo;
    }

    public override void OnTick()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.isStopped = true;
    }
}
