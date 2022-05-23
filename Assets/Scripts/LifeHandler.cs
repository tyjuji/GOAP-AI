using System.Collections;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    public GameObject Bullet;
    public int startingHealth = 15;
    public int startingAmmo = 30;

    public const float shieldCooldown = 10f;
    public const int shieldDuration = 5;


    public int Health { get; private set; }
    public int Ammo { get; private set; }

    private float _shieldLastUse = -shieldCooldown;

    public bool ShieldAvailable
    {
        get { return Time.time > _shieldLastUse + shieldCooldown; }
    }

    GameObject shield;
    private float _lastShot;
    


    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
        Ammo = startingAmmo;

        shield = transform.Find("Shield").gameObject;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShieldOn()
    {
        if (ShieldAvailable)
        {
            StartCoroutine(ShieldOff());
        }
        else
        {
            Debug.Log("Shield not ready yet");
        }
    }

    private IEnumerator ShieldOff()
    {
        _shieldLastUse = Time.time + shieldDuration;
        shield.SetActive(true);

        yield return new WaitForSeconds(shieldDuration);
        shield.SetActive(false);

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

    //public void UseAmmo()
    //{
    //    Ammo--;
    //}

    public void Shoot()
    {
        if (Time.time > _lastShot + 0.25f && Ammo > 0)
        {
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            Ammo--;
            _lastShot = Time.time;
        }
    }
}
