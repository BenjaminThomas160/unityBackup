using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public float spawnTime;
    public bool stopSpawning = false;
    public float spawnDelay;
    public int maxSpawn = 10;
    public int numbSpawned = 0;
    public LayerMask playerMask;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }
    public void Spawn()
    {
        if (Physics.CheckSphere(transform.position, 10, playerMask))
        {
            Instantiate(spawnObject, transform.position, transform.rotation);
            if (stopSpawning || numbSpawned >= maxSpawn)
            {
                CancelInvoke("Spawn");
            }
        }
    }
}
