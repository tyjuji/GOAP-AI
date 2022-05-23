using UnityEngine;

public class Goal_Base : MonoBehaviour, IGoal
{
    //protected CharacterAgent Agent;
    //protected AwarenessSystem Sensors;
    protected GOAPUI DebugUI;
    protected Action_Base LinkedAction;

    void Awake()
    {
        //Agent = GetComponent<CharacterAgent>();
        //Sensors = GetComponent<AwarenessSystem>();
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