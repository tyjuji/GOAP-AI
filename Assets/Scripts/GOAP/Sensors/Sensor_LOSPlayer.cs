using UnityEngine;

public class Sensor_LOSPlayer : MonoBehaviour
{
    public bool CanSeePlayer;

    float? losLastTime = null;

    public float dangerFactor = 0f;
    public float dangerRate = 10f;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var hasLOS = LineOfSight();

        if (hasLOS && losLastTime == null)
        {
            losLastTime = Time.time;
        }
        else if (hasLOS && Time.time > losLastTime + 0.25f)
        {
            CanSeePlayer = true;

            //if(dangerFactor < 0f)
            //{
            //    dangerFactor = 0f;
            //}
        }
        else if (!hasLOS)
        {
            losLastTime = null;
            CanSeePlayer = false;
        }

        if (hasLOS)
        {
            dangerFactor += dangerRate * Time.deltaTime;
            Debug.Log(dangerFactor);
        }
        else
        {
            dangerFactor -= dangerRate * 1.2f * Time.deltaTime;
        }


    }

    bool LineOfSight()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8 | 1 << 7;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        if (!Physics.Linecast(transform.position, player.transform.position, layerMask))
        {
            return true;
        }
        return false;
    }
}
