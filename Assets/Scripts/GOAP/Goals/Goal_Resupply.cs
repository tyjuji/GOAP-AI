using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Resupply : Goal_Base
{
    public override int CalculatePriority()
    {
        var ammoPrio = ((lifeHandler.startingAmmo - lifeHandler.Ammo) / (float)lifeHandler.startingAmmo) * 75f;
        var healthPrio = ((lifeHandler.startingHealth - lifeHandler.Health) / (float)lifeHandler.startingHealth) * 80f;

        return (int)Mathf.Max(healthPrio, ammoPrio);
    }

    public override bool CanRun()
    {
        return lifeHandler.AmmoAvailable || lifeHandler.HealthAvailable;
    }
}
