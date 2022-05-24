using UnityEngine;
using UnityEngine.AI;

public abstract class Goal_Base : MonoBehaviour
{
    protected GOAPUI DebugUI;
    protected Action_Base LinkedAction;


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

    void Start()
    {
        DebugUI = FindObjectOfType<GOAPUI>();
        //Debug.Log(DebugUI);
    }

    void Update()
    {
        OnTickGoal();

        DebugUI.UpdateGoal(this, GetType().Name, LinkedAction ? "Running" : "Paused", CalculatePriority());
        //Debug.Log(this);
    }

    public virtual int CalculatePriority()
    {
        return -1;
    }

    public virtual bool CanRun()
    {
        return false;
    }

    public virtual void OnTickGoal()
    {

    }

    public virtual void OnGoalActivated(Action_Base _linkedAction)
    {
        LinkedAction = _linkedAction;
    }

    public virtual void OnGoalDeactivated()
    {
        LinkedAction = null;
    }
}