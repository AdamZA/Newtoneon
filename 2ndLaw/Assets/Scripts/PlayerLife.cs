using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    private bool playerDeath; 

	void Start ()
    {
        playerDeath = false;
	}

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag ("Death"))
        {
            playerDeath = true;
            //send out an alert
            //temp test: destroy gameobject
            Destroy(this.gameObject);
        }
    }
}
