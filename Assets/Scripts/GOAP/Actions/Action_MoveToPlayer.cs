using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action_MoveToPlayer : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(
        new System.Type[] { typeof(Goal_Attack) });


    LifeHandler lifeHandler;
    NavMeshAgent navMeshAgent;
    GameObject player;
    Sensor_LOSPlayer los;

    void Awake()
    {
        lifeHandler = GetComponent<LifeHandler>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        los = GetComponent<Sensor_LOSPlayer>();

    }

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override bool CanRun()
    {
        return Vector3.Distance(transform.position, player.transform.position) > 100f || !los.CanSeePlayer;
    }

    public override float GetCost()
    {
        return 1 / (lifeHandler.startingHealth / lifeHandler.Health * 100f);
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        navMeshAgent.SetDestination(player.transform.position);
        LinkedGoal = _linkedGoal;
    }

    public override void OnDeactivated()
    {
        navMeshAgent.SetDestination(gameObject.transform.position);
        LinkedGoal = null;
    }


    public override void OnTick()
    {
        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.Move(Vector3.zero);
    }
}
