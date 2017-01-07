using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDespawnScript : MonoBehaviour
{

	public float despawnTime = 3.0f;
	void Start ()
    {
        Destroy(this.gameObject, despawnTime);
	}

}
