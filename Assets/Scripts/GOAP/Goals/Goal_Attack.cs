using UnityEngine;

public class Goal_Attack : Goal_Base
{

    LifeHandler lifeHandler;

    void Awake()
    {
        lifeHandler = GetComponent<LifeHandler>();
    }

    //// Start is called before the first frame update
    //void Start()
    //{
    //    DebugUI = FindObjectOfType<GOAPUI>();
    //    lifeHandler = GetComponent<LifeHandler>();
    //}

    //void Update()
    //{
    //    OnTickGoal();
    //    Debug.Log(this);
    //    DebugUI.UpdateGoal(this, GetType().Name, LinkedAction ? "Running" : "Paused", CalculatePriority());

    //}

    // Update is called once per frame
    public override int CalculatePriority()
    {
        //Debug.Log(((lifeHandler.Ammo / lifeHandler.startingAmmo) +
        //    (lifeHandler.Health / lifeHandler.startingHealth)) / 2 * 100);
        var prio = Mathf.FloorToInt(((float)lifeHandler.Health / (float)lifeHandler.startingHealth) * 100f);
        //Debug.Log(prio);
        //Debug.Log(lifeHandler.Health);
        return prio;
    }

    public override bool CanRun()
    {
        return lifeHandler.Ammo > 0;
    }
}
