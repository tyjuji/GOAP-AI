using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Action_Base : MonoBehaviour
{
    protected Goal_Base LinkedGoal;


    protected LifeHandler lifeHandler;
    protected NavMeshAgent navMeshAgent;
    protected GameObject player;
    protected Sensor_LOSPlayer los;

    void Awake()
    {
        lifeHandler = GetComponent<LifeHandler>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        los = GetComponent<Sensor_LOSPlayer>();
    }

    public virtual List<System.Type> GetSupportedGoals()
    {
        return null;
    }

    public virtual bool CanRun()
    {
        return true;
    }

    public virtual float GetCost()
    {
        return 0f;
    }

    public virtual void OnActivated(Goal_Base _linkedGoal)
    {
        LinkedGoal = _linkedGoal;
    }

    public virtual void OnDeactivated()
    {
        LinkedGoal = null;
    }

    public virtual void OnTick()
    {

    }
}