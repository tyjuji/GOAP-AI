using UnityEngine;

public class Goal_Attack : Goal_Base
{
    public override int CalculatePriority()
    {
        //Debug.Log(((lifeHandler.Ammo / lifeHandler.startingAmmo) +
        //    (lifeHandler.Health / lifeHandler.startingHealth)) / 2 * 100);
        //var prio = Mathf.FloorToInt(((float)lifeHandler.Health / (float)lifeHandler.startingHealth) * 100f);
        var prio = (((float)lifeHandler.Ammo / lifeHandler.startingAmmo) +
            ((float)lifeHandler.Health / lifeHandler.startingHealth)) / 2f * 100f;
        return Mathf.FloorToInt(prio);
    }

    public override bool CanRun()
    {
        return lifeHandler.Ammo > 0 && player.activeSelf;
    }
}
