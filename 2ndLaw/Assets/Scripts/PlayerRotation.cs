using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	public float rotationSpeed = 0.1f;
	//public GameObject centerPoint;
	//private Transform centerPos;



	void Start () {
		//centerPos = centerPoint.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Rigidbody2D>().transform.Rotate(Vector3.forward, rotationSpeed);
	}
}
