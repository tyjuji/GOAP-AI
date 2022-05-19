using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject enemyBullet;


    //int walkSpeed = 5;

    NavMeshAgent navMeshAgent;

    GameObject player;
    Rigidbody rb;

    float _lastShot = 0;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = navMeshAgent.GetComponent<Rigidbody>();


        //navMeshAgent.updatePosition = false;
        //navMeshAgent.updateRotation = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterMovement();
        if (LineOfSight())
        {
            navMeshAgent.updateRotation = false;
            transform.LookAt(player.transform.position);
            //https://africacomicade.org/predictable-projectile-in-unity/
            Shooting();
        }
        else
        {
            navMeshAgent.updateRotation = true;
        }
        
    }

    bool LineOfSight()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;
        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        if(!Physics.Linecast(transform.position, player.transform.position, layerMask))
        {
            return true;
        }
        return false;
    }
    private void Shooting()
    {
        if (Time.time > _lastShot + 0.3f)
        {
            Instantiate(enemyBullet, gameObject.transform.position, gameObject.transform.rotation);
            _lastShot = Time.time;
        }
    }

    private void CharacterMovement()
    {
        navMeshAgent.SetDestination(player.transform.position);
        //rb.AddForce(navMeshAgent.desiredVelocity);
        navMeshAgent.Move(Vector3.zero);
    }
}
