using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public float spawnDelay;
    public float spawnRate;
    private int spawnCount;
    private GameObject[] _spawners;
    

	// Use this for initialization
	void Start ()
    {
        _spawners = GameObject.FindGameObjectsWithTag("Spawner");
        spawnDelay = 2.0f;
        spawnRate = 5.0f;
        InvokeRepeating("SpawnEnemies", spawnDelay, spawnRate);
    }
	
	public void SpawnEnemies()
    {
        if(_spawners.Length > 0)
        {
            if (spawnCount % 10 == 0 && spawnRate > 2.0f)
            {
                spawnRate -= 0.5f;
            }

            int spawnerToUse = Mathf.RoundToInt(Random.Range(0, _spawners.Length - 1));
            float spawnerPosX = _spawners[spawnerToUse].transform.position.x;
            float spawnerLocalScaleX = _spawners[spawnerToUse].transform.localScale.x;
            float spawnX = Random.Range(Mathf.Min(spawnerPosX, spawnerLocalScaleX), Mathf.Max(spawnerPosX, spawnerLocalScaleX));

            float spawnerPosY = _spawners[spawnerToUse].transform.position.y;
            float spawnerLocalScaleY = _spawners[spawnerToUse].transform.localScale.y;
            float spawnY = Random.Range(Mathf.Min(spawnerPosY, spawnerLocalScaleY), Mathf.Max(spawnerPosY, spawnerLocalScaleY));

            Instantiate(basicEnemy, new Vector3(spawnX, spawnY, 1.0f), Quaternion.identity);
            spawnCount++;
        }
    }
}
