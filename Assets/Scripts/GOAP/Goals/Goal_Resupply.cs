using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Resupply : Goal_Base
{
    public override int CalculatePriority()
    {
        var ammoPrio = ((lifeHandler.startingAmmo - lifeHandler.Ammo) / (float)lifeHandler.startingAmmo) * 100f;
        //var healthPrio = lifeHandler.Health / lifeHandler.startingHealth * 100f;
        //var healthPrio = 0f;
        //return (int)((lifeHandler.startingAmmo / lifeHandler.Ammo * 100f) + (lifeHandler.startingHealth / lifeHandler.Health * 100f)) / 2;
        //Debug.Log((int)ammoPrio);
        return (int)ammoPrio;
    }

    public override bool CanRun()
    {
        //Debug.Log(lifeHandler.AmmoAvailable);
        //Debug.Log(lifeHandler.ammoPickups[0]);
        return lifeHandler.AmmoAvailable;
    }
}
