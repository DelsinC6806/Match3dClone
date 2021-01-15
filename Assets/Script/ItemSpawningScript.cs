using UnityEngine;

public class ItemSpawningScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] items;
    int count = 0 ;
    int itemamount = 10;

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
            itemamount += 5;
            Spawn();
        }
    }

    void Spawn()
    {
        if(count < itemamount)
        {
            int index = Random.Range(0,items.Length-1);
            Instantiate(items[index], spawnPoint.position,Quaternion.identity);
            Vector3 newSpawnPoint = spawnPoint.position;
            newSpawnPoint.x = Random.Range(28, 72);
            newSpawnPoint.z = Random.Range(5, 25);
            spawnPoint.position = newSpawnPoint;
            Instantiate(items[index], spawnPoint.position,Quaternion.identity);
            count += 2;
        }
    }
}
