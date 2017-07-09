using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public bool isPaused;
	public float rotationSpeed;

    public void Start()
    {
        isPaused = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if(!isPaused)
        {
            GetComponent<Rigidbody2D>().transform.Rotate(Vector3.forward, -1 * rotationSpeed);
        }
	}
}
