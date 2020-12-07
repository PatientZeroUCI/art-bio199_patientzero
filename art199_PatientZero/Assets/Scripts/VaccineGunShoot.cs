using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VaccineGunShoot : VRTK.Examples.GunShoot
{
    public int vaccineType = 0;
    public Material[] materials;

    protected override void FireProjectile()
    {
        if (projectile != null && projectileSpawnPoint != null)
        {
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
}
