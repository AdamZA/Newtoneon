using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Basic : MonoBehaviour {

    private Transform _playerTransform;
    public float speed;
	// Use this for initialization
	void Start ()
    {
        speed = 1.2f;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
