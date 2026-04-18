using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBasic : MonoBehaviour
{

    private Transform _playerTransform;
    public float speed;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        GameObject gsm = GameObject.FindGameObjectWithTag("GameStateManager");
        if (gsm != null)
        {
            GameStateManager manager = gsm.GetComponent<GameStateManager>();
            if (manager != null) speed = manager.enemyStartSpeed;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) _playerTransform = player.transform;
    }

    void Update()
    {
        if (_playerTransform != null)
        {
            RotateTowardsPlayer();
        }

        _rb.velocity = transform.right * speed;
    }

    void RotateTowardsPlayer()
    {
        float angle = Mathf.Atan2((_playerTransform.position.y - transform.position.y), (_playerTransform.position.x - transform.position.x)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
