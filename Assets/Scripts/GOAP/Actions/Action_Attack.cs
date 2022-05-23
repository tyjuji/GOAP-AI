using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Action_Attack : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(
            new System.Type[] { typeof(Goal_Attack) });


    LifeHandler lifeHandler;
    NavMeshAgent navMeshAgent;
    GameObject player;

    void Awake()
    {
        lifeHandler = GetComponent<LifeHandler>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }


    public override float GetCost()
    {
        return lifeHandler.Health / lifeHandler.startingHealth * 100f;
    }

    public override void OnTick()
    {
        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.Move(Vector3.zero);
    }
}

