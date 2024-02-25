using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDamage : MonoBehaviour
{
    [SerializeField] private GameObject morgenshternToSpawn;
    [SerializeField] private float spawnInterval = 2f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;    
        }
    }

    void SpawnObject()
    {
        Instantiate(morgenshternToSpawn, transform.position, Quaternion.identity); 
    }
}
