using UnityEngine;

public class Sensor_LOSPlayer : MonoBehaviour
{
    public bool CanSeePlayer;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer = LineOfSight();
    }

    bool LineOfSight()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;
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
