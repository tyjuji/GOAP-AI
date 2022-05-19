using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehaviour : MonoBehaviour
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
            //Debug.Log("collided player");
        }
        else if (other.CompareTag("Gun"))
        {
            // also do nothing
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("collided enemy");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("collided obstacle");
            Destroy(gameObject);
        }
    }
}
