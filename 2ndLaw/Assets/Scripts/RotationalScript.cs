using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalScript : MonoBehaviour
{
    //Object references
    public Transform playerObject;

    //Class Variables
    private float speed = 3.0f;
    private Vector2 _centre;
    private float _angle;
    private float _radius;

    // Use this for initialization
    void Start ()
    {
        _angle = 0;
        _centre = playerObject.transform.position;
        _radius = 0.8f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        _centre = playerObject.transform.position;
        _angle += speed * -Time.deltaTime; //if you want to switch direction, use -= instead of +=
        var x = Mathf.Cos(_angle);
        var y = Mathf.Sin(_angle);
        transform.localPosition = new Vector3(x* _radius, y * _radius, transform.localPosition.z);
    }
}
