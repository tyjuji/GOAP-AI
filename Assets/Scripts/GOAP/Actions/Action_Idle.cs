using System.Collections.Generic;
using UnityEngine;

public class Action_Idle : Action_Base
{
    public float RotateSpeed = 15f;

    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Idle) });

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        navMeshAgent.SetDestination(gameObject.transform.position);
        navMeshAgent.Move(Vector3.zero);
        navMeshAgent.updateRotation = false;
        navMeshAgent.isStopped = true;

        base.OnActivated(_linkedGoal);
    }

    public override bool CanRun()
    {
        return true;
    }

    public override float GetCost()
    {
        return 0f;
    }

    public override void OnTick()
    {
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
    }
}
