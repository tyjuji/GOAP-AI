using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHandler : MonoBehaviour
{
    public GameObject Bullet;
    public int startingHealth = 15;
    public int startingAmmo = 30;

    public const float shieldCooldown = 10f;
    public const int shieldDuration = 5;

    [HideInInspector]
    public GameObject[] ammoPickups;
    [HideInInspector]
    public GameObject[] healthPickups;
    [HideInInspector]
    public GameObject[] retreats;

    GameObject player;
    GameObject shield;
    private float _lastShot;

    public int Health { get; private set; }
    public int Ammo { get; private set; }

    private float _shieldLastUse = -shieldCooldown;
    bool _shieldUp = false;

    public bool ShieldAvailable
    {
        get { return Time.time > _shieldLastUse + shieldCooldown; }
    }

    public bool AmmoAvailable
    {
        get { 
            var gos = FindNearestActive(ammoPickups);
            return gos != null;
        }
    }

    public bool HealthAvailable
    {
        get
        {
            var gos = FindNearestActive(healthPickups);
            return gos != null;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
        Ammo = startingAmmo;

        player = GameObject.FindGameObjectWithTag("Player");

        ammoPickups = GameObject.FindGameObjectsWithTag("Ammo");
        healthPickups = GameObject.FindGameObjectsWithTag("Health");
        retreats = GameObject.FindGameObjectsWithTag("Retreat");

        shield = transform.Find("Shield").gameObject;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public GameObject FindNearestActive(GameObject[] gos)
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

        return closest;
    }

    public GameObject FindFurthestFromPlayer(GameObject[] gos)
    {
        //List<GameObject> actives = new();

        //foreach (var item in gos)
        //{
        //    if (item.activeSelf)
        //    {
        //        actives.Add(item);
        //    }
        //}

        float distance = Mathf.NegativeInfinity;
        GameObject furthest = null;

        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - player.transform.position;
            float curDistance = diff.sqrMagnitude;
            //Debug.Log(curDistance);
            if (curDistance > distance)
            {
                furthest = go;
                distance = curDistance;
            }
        }

        return furthest;
    }

    public void ShieldOn()
    {
        if (ShieldAvailable)
        {
            StartCoroutine(ShieldOff());
        }
        else
        {
            //Debug.Log("Shield not ready yet");
        }
    }

    private IEnumerator ShieldOff()
    {
        _shieldLastUse = Time.time + shieldDuration;
        shield.SetActive(true);
        _shieldUp = true;
        yield return new WaitForSeconds(shieldDuration);
        _shieldUp = false;
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
        if (Time.time > _lastShot + 0.25f && Ammo > 0 && !_shieldUp)
        {
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            Ammo--;
            _lastShot = Time.time;
        }
    }
}
