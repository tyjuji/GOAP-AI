using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject enemyBullet;


    NavMeshAgent navMeshAgent;
    LifeHandler lifeHandler;
    GameObject player;
    GameObject[] ammoPickups;
    GameObject[] healthPickups;


    float _lastShot = 0;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        lifeHandler = GetComponent<LifeHandler>();

        ammoPickups = GameObject.FindGameObjectsWithTag("Ammo");
        healthPickups = GameObject.FindGameObjectsWithTag("Health");

        //navMeshAgent.updatePosition = false;
        //navMeshAgent.updateRotation = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lifeHandler.Health <= 5)
        {
            // Get more health
            var nearestHealth = FindNearestActive(healthPickups);
            MoveTo(nearestHealth);
        }
        else if (lifeHandler.Ammo > 0)
        {
            MoveTo(player);
        }
        else
        {
            // Get more ammo
            var nearestAmmo = FindNearestActive(ammoPickups);
            MoveTo(nearestAmmo);
        }


        if (LineOfSight() && lifeHandler.Ammo > 0)
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

    GameObject FindNearestActive(GameObject[] gos)
    {
        List<GameObject> actives = new();

        foreach (var item in gos)
        {
            if (item.activeSelf)
            {
                actives.Add(item);
            }
        }

        float distance = Mathf.Infinity;
        GameObject closest = null;

        foreach (GameObject go in actives)
        {
            Vector3 diff = go.transform.position - gameObject.transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        
        // Hack to make sure we always have a target.
        return closest != null ? closest : player;
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

    private void Shooting()
    {
        if (Time.time > _lastShot + 0.3f && lifeHandler.Ammo > 0)
        {
            Instantiate(enemyBullet, gameObject.transform.position, gameObject.transform.rotation);
            lifeHandler.UseAmmo();
            _lastShot = Time.time;
        }
    }

    private void MoveTo(GameObject go)
    {
        navMeshAgent.SetDestination(go.transform.position);
        //rb.AddForce(navMeshAgent.desiredVelocity);
        navMeshAgent.Move(Vector3.zero);
    }
}
