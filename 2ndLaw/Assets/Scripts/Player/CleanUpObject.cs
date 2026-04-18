using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpObject: MonoBehaviour
{

	public float despawnTime = 2.0f;
	void Start ()
    {
        Destroy(gameObject, despawnTime);
	}

}
