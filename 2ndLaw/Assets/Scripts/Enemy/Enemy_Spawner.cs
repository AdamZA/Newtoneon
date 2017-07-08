using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public float spawnDelay;
    public float spawnRate;
    private int spawnCount;
    private bool playerAlive;
    private GameObject[] _spawners;
    

	// Use this for initialization
	void Start ()
    {
        playerAlive = true;
        _spawners = GameObject.FindGameObjectsWithTag("Spawner");
        spawnDelay = 2.0f;
        spawnRate = 5.0f;
        InvokeRepeating("SpawnEnemies", spawnDelay, spawnRate);
    }
	
	public void SpawnEnemies()
    {
        if(playerAlive)
        {
            if (_spawners.Length > 0)
            {
                if (spawnCount % 10 == 0 && spawnRate > 2.0f)
                {
                    spawnRate -= 0.5f;
                }

                int spawnerToUse = Mathf.RoundToInt(Random.Range(0, _spawners.Length - 1));
                float spawnerMaxX = _spawners[spawnerToUse].GetComponent<BoxCollider>().bounds.max.x;
                float spawnerMinX = _spawners[spawnerToUse].GetComponent<BoxCollider>().bounds.min.x;
                float spawnX = Random.Range(Mathf.Min(spawnerMaxX, spawnerMinX), Mathf.Max(spawnerMaxX, spawnerMinX));

                float spawnerMaxY = _spawners[spawnerToUse].GetComponent<BoxCollider>().bounds.max.y;
                float spawnerMinY = _spawners[spawnerToUse].GetComponent<BoxCollider>().bounds.min.y;
                float spawnY = Random.Range(Mathf.Min(spawnerMaxY, spawnerMinY), Mathf.Max(spawnerMaxY, spawnerMinY));

                Instantiate(basicEnemy, new Vector3(spawnX, spawnY, 1.0f), Quaternion.identity);
                spawnCount++;
            }
        }
    }
}
