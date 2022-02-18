using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VaccineGunShoot : VRTK.Examples.GunShoot
{
    public int vaccineType = 0;
    public Material[] materials;

    // Variables sued to control ammo/laoding the vaccine from the port
    private int ammo = 0;
    public int reloadAmount = 5; // How much ammo the gun should get when inserted intot he port
    public GameObject reloadPort;

    public float timer = 0f;  // how long the gun ahs been charging
    public float chargeTime = 1f;  // How long the gun has to charge to reload
    private bool charging = false;


    // Models that are used depending on if the gun is loaded or not
    public GameObject emptyGun;
    public GameObject loadedGun;


    private void Start()
    {
        chargeTime = chargeTime / Time.fixedDeltaTime;
    }

    private void Update()
    {
    }


    private void FixedUpdate()
    {
        //Debug.Log(timer);
        if (charging)
        {
            // If charging, starting increasing timer
            timer += 1;
        }
        else
        {
            // If not charging, remove all charge time
            timer = 0;
        }

        // When charged for long enough, reload gun
        if (timer > chargeTime)
        {
            Reload();
        }


        if ((loadedGun != null) && (emptyGun != null))
        {
            if (ammo > 0)
            {
                loadedGun.SetActive(true);
                emptyGun.SetActive(false);
            }
            else
            {
                loadedGun.SetActive(false);
                emptyGun.SetActive(true);
            }
        }
    }


    protected override void FireProjectile()
    {
        Debug.Log(ammo);
        if (projectile != null && projectileSpawnPoint != null && (ammo > 0))
        {
            Debug.Log("123");
            // Reduce ammo by one
            ammo -= 1;

            GameObject clonedProjectile = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Rigidbody projectileRigidbody = clonedProjectile.GetComponent<Rigidbody>();
            float destroyTime = 0f;
            if (projectileRigidbody != null)
            {
                projectileRigidbody.AddForce(clonedProjectile.transform.forward * projectileSpeed);
                destroyTime = projectileLife;
            }
            clonedProjectile.GetComponent<VaccineBullet>().vaccineType = vaccineType;
            clonedProjectile.transform.Find("Base").GetComponent<MeshRenderer>().material = materials[vaccineType];

            Destroy(clonedProjectile, destroyTime);
        }
    }

    public void NextVaccine()
    {
        vaccineType++;
        if (vaccineType >= 2) { vaccineType = 0; }

        transform.Find("Barrel").GetComponent<MeshRenderer>().material = materials[vaccineType];
    }

    public void Reload()
    {
        ammo = reloadAmount;
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (reloadPort != null)
        {
            if (other.gameObject == reloadPort)
            {
                //Reload();

                charging = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (reloadPort != null)
        {
            if (other.gameObject == reloadPort)
            {
                //Reload();

                charging = false;
            }
        }
    }
}
