using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public float spawnDelay;
    public float spawnRate;
    private int spawnCount;
    public bool playerAlive;
    private GameObject[] _spawners;
    private int _totalSpawners;
    

	// Use this for initialization
	void Start ()
    {
        _totalSpawners = 0;
        playerAlive = true;
        _spawners = GameObject.FindGameObjectsWithTag("Spawner");
        InvokeRepeating("SpawnEnemies", spawnDelay, spawnRate);
        _totalSpawners++;
    }
	
	public void SpawnEnemies()
    {
        if(playerAlive)
        {
            if (_spawners.Length > 0)
            {
                if (spawnCount % 5 == 0 && spawnRate > 0.5f)
                {
                    spawnRate -= 0.5f;
                }
                else if (spawnCount % 5 == 0 && _totalSpawners <= 8)
                {
                    InvokeRepeating("SpawnEnemies", 2, 5);
                    _totalSpawners++;
                }
                
                int spawnerToUse = Mathf.RoundToInt(Random.Range(0, _spawners.Length));
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
