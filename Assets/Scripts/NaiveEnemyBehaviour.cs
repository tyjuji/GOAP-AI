using UnityEngine;
using UnityEngine.AI;

public class NaiveEnemyBehaviour : MonoBehaviour
{
    //int walkSpeed = 5;

    NavMeshAgent navMeshAgent;

    GameObject player;
    Rigidbody rb;


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
    }

    private void CharacterMovement()
    {
        navMeshAgent.SetDestination(player.transform.position);
        //rb.AddForce(navMeshAgent.desiredVelocity);
        navMeshAgent.Move(Vector3.zero);
    }
}
