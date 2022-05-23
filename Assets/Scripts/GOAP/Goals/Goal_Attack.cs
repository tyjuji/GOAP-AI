using UnityEngine;

public class Goal_Attack : MonoBehaviour
{

    LifeHandler lifeHandler;


    // Start is called before the first frame update
    void Start()
    {
        lifeHandler = GetComponent<LifeHandler>();
    }

    // Update is called once per frame
    public virtual int CalculatePriority()
    {
        return ((lifeHandler.Ammo / lifeHandler.startingAmmo) +
            (lifeHandler.Health / lifeHandler.startingHealth)) / 2 * 100;
    }

    public virtual bool CanRun()
    {
        return lifeHandler.Ammo > 0;
    }
}
