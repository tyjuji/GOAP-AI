using UnityEngine;

public class Goal_Idle : Goal_Base
{
    public int Priority = 10;

    public override int CalculatePriority()
    {
        return Priority;
    }

    public override bool CanRun()
    {
        return true;
    }
}
