using UnityEngine;

public class Sensor_LOSPlayer : MonoBehaviour
{
    public bool CanSeePlayer;

    float? _losLastTime = null;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (LineOfSight() && _losLastTime == null)
        {
            _losLastTime = Time.time;
        }
        else if (LineOfSight() && Time.time > _losLastTime + 0.25f)
        {
            CanSeePlayer = true;
        }
        else if (!LineOfSight())
        {
            _losLastTime = null;
            CanSeePlayer = false;
        }
        //Debug.Log(_losLastTime);
    }

    bool LineOfSight()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8 | 1 << 7;
        //Debug.Log(layerMask);
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
