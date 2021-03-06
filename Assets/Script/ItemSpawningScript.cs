﻿using UnityEngine;

public class ItemSpawningScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] items;
    int count = 0 ;
    int itemamount = 0;

    void Update()
    {
        Invoke("Spawn", 0.2f);
    }

    private void LateUpdate()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("draggable");
        if(gameObjects.Length == 0)
        {
            LevelScript.level += 1;
            count = 0;
            itemamount += 2 * LevelScript.level;
            TimerScript.minute += LevelScript.level /2;
            Spawn();
        }
    }

    void Spawn()
    {
        if(count < itemamount)
        {
            int index = Random.Range(0,LevelScript.level);
            Instantiate(items[index], spawnPoint.position,Quaternion.identity);
            spawnPoint.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
            Instantiate(items[index], spawnPoint.position,Quaternion.identity);
            count += 2;
        }
    }
}
