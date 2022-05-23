using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action_Idle : Action_Base
{
    public float RotateSpeed = 10f;

    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Idle) });

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override float GetCost()
    {
        return 0f;
    }

    public override void OnTick()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.isStopped = true;
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
    }
}
