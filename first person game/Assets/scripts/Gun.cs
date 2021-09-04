using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float rocketRange = 100f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;
    public GameObject rocketBullet;
    public Transform bulletSpawn;
    public float bulletSpeed = 30f;

    public float lifeTime = 3f;

    private Vector3 destination;
    
   

    public Camera fpsCam;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            if (WeaponSwitching.selectedWeapon == 0)
            {
                Shoot();
            }
            else if (WeaponSwitching.selectedWeapon == 1)
            {
                RocketLauncher();
            }
            else if (WeaponSwitching.selectedWeapon == 2)
            {
                if (Input.GetKey(KeyCode.Mouse1)) 
                { 
                    sniperRifle();
                }
            }

        }
       
    }
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 2f);
        }
    }
    void RocketLauncher()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit dest;
        if (Physics.Raycast(ray, out dest, rocketRange))
        {
            destination = dest.point;
        } 
        else
        {
            destination = ray.GetPoint(1000);
        }

        GameObject bullet = Instantiate(rocketBullet, bulletSpawn.position, bulletSpawn.rotation);
        //Vector3 rotation = bullet.transform.rotation.eulerAngles;

        //bullet.transform.rotation = Quaternion.Euler(rotation.x + 90, transform.rotation.y, rotation.z + 90);
        
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());
        bullet.GetComponent<Rigidbody>().velocity = (destination - bulletSpawn.position).normalized * bulletSpeed;

        Destroy(bullet, lifeTime);
    }
    void sniperRifle()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(50f);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 2f);
        }
    }
}
