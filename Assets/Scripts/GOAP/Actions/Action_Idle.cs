using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action_Idle : Action_Base
{
    public float RotateSpeed = 10f;

    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Idle) });
    NavMeshAgent navMeshAgent;

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override float GetCost()
    {
        return 0f;
    }

    public override void OnTick()
    {
        navMeshAgent.updateRotation = false;
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
    }
}
