using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{

    public int ProjectileSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Shot player");
            Destroy(gameObject);
        }
        else if (other.CompareTag("Gun"))
        {
            // also do nothing
        }
        else if (other.CompareTag("Enemy"))
        {
            // nothing
        }
        else
        {
            Debug.Log("collided obstacle");
            Destroy(gameObject);
        }
    }
}
