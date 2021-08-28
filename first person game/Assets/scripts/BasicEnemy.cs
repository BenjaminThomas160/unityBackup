using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    public float minDist = 20f;
    public float maxDist = 30f;
    public NavMeshAgent nav;
    private Vector3 direction;
    public GameObject bullet;
    float fireRate = 1f;
    float nextFire;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (Vector3.Distance(transform.position, player.transform.position) >= minDist && Vector3.Distance(transform.position, player.transform.position) <= maxDist) 
        {
            if (angle >= -80 && angle <= 80)
            {
                nav.SetDestination(player.transform.position);
            }
        } 
        else if (Vector3.Distance(transform.position, player.transform.position) < minDist)
        {
            if (angle >= -80 && angle <= 80)
            {
                nav.SetDestination(transform.position);
                transform.LookAt(player.transform);

                Fire();
            }
        }
    }
    void Fire()
    {
        if (Time.time > nextFire)
        {
            GameObject bulletTemp = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            Destroy(bulletTemp, 5f);
        }
    }
}
