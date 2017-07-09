using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBasic : MonoBehaviour
{

    private GameObject _playerObject;
    private Transform _playerTransform;
    private GameObject _gameStateManager;
    public float speed;
	// Use this for initialization
	void Start ()
    {
        _gameStateManager = GameObject.FindGameObjectWithTag("GameStateManager");
        if(_gameStateManager != null)
        {
            speed = _gameStateManager.GetComponent<GameStateManager>().enemyStartSpeed;
        }
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        if(_playerObject != null)
        {
            _playerTransform = _playerObject.transform;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_playerTransform != null)
        {
            RotateTowardsPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
		
    }

    void RotateTowardsPlayer()
    {
        float angle = Mathf.Atan2((_playerTransform.position.y - transform.position.y), (_playerTransform.position.x - transform.position.x)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
