using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public float spawnDelay;
    public float spawnRate;
    private int enemiesSpawned;
    public bool playerAlive;
    private GameObject[] _spawners;
    private int _enemiesToSpawn;
    private bool _spawnAdded;
    

	// Use this for initialization
	void Start ()
    {
        _enemiesToSpawn = 1;
        playerAlive = true;
        _spawners = GameObject.FindGameObjectsWithTag("Spawner");
        InvokeRepeating("SpawnEnemies", spawnDelay, spawnRate);
        _spawnAdded = false;
    }
	
	public void SpawnEnemies()
    {
        if(playerAlive)
        {
            if (_spawners.Length > 0)
            {
                if (enemiesSpawned != 0 && enemiesSpawned % 20 == 0 && _enemiesToSpawn < 15)
                {
                    _enemiesToSpawn++;
                }
                
                for(int i = 0; i < _enemiesToSpawn; i++)
                {
                    int spawnerToUse = Mathf.RoundToInt(Random.Range(0, _spawners.Length));
                    float spawnerMaxX = _spawners[spawnerToUse].GetComponent<BoxCollider>().bounds.max.x;
                    float spawnerMinX = _spawners[spawnerToUse].GetComponent<BoxCollider>().bounds.min.x;
                    float spawnX = Random.Range(Mathf.Min(spawnerMaxX, spawnerMinX), Mathf.Max(spawnerMaxX, spawnerMinX));

                    float spawnerMaxY = _spawners[spawnerToUse].GetComponent<BoxCollider>().bounds.max.y;
                    float spawnerMinY = _spawners[spawnerToUse].GetComponent<BoxCollider>().bounds.min.y;
                    float spawnY = Random.Range(Mathf.Min(spawnerMaxY, spawnerMinY), Mathf.Max(spawnerMaxY, spawnerMinY));

                    Instantiate(basicEnemy, new Vector3(spawnX, spawnY, 1.0f), Quaternion.identity);
                    enemiesSpawned++;
                }
            }
        }
    }
}
