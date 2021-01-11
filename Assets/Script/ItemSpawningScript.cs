using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawningScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] items;
    int count = 0 ;

    void Update()
    {
        Invoke("Spawn", 0.2f);
    }

    void Spawn()
    {
        if(count < 50)
        {
            int index = Random.Range(0,items.Length-1);
            Instantiate(items[index], spawnPoint.position,Quaternion.identity);
            Instantiate(items[index], spawnPoint.position,Quaternion.identity);
            Vector3 newSpawnPoint = spawnPoint.position;
            newSpawnPoint.y += 2;
            spawnPoint.position = newSpawnPoint;
            count += 2;
            Debug.Log(count);
        }
    }
}
