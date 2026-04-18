using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public bool isPaused;
    public float rotationSpeed;

    private Rigidbody2D _rb;

    public void Start()
    {
        isPaused = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isPaused)
        {
            _rb.transform.Rotate(Vector3.forward, -1 * rotationSpeed);
        }
    }
}
