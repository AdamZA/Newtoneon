using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

	public float rotationSpeed;

	// Update is called once per frame
	void Update ()
    {
		this.GetComponent<Rigidbody2D>().transform.Rotate(Vector3.forward, -1 * rotationSpeed);
	}
}
