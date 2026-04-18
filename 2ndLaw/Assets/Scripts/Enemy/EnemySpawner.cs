using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float spawnRate;
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
                    int spawnerToUse = Random.Range(0, _spawners.Length);
                    BoxCollider spawnerCollider = _spawners[spawnerToUse].GetComponent<BoxCollider>();
                    if (spawnerCollider == null) continue;

                    Bounds bounds = spawnerCollider.bounds;
                    float spawnX = Random.Range(bounds.min.x, bounds.max.x);
                    float spawnY = Random.Range(bounds.min.y, bounds.max.y);

                    Instantiate(basicEnemy, new Vector3(spawnX, spawnY, 1.0f), Quaternion.identity);
                    enemiesSpawned++;
                }
            }
        }
    }
}
