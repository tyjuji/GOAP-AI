using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    public int startingHealth = 15;
    public int startingAmmo = 30;

    public int Health { get; private set; }
    public int Ammo { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
        Ammo = startingAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health"))
        {
            Health = startingHealth;
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Ammo"))
        {
            Ammo = startingAmmo;
            other.gameObject.SetActive(false);
        }
    }

    public void LoseHealth()
    {
        Health--;

        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void UseAmmo()
    {
        Ammo--;
    }
}
