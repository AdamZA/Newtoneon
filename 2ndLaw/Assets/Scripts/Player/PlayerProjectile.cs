using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile: MonoBehaviour
{

	public float despawnTime = 3.0f;
	void Start ()
    {
        Destroy(gameObject, despawnTime);
	}

}
