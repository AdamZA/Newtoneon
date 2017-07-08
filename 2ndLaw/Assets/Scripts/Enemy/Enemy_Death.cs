using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("PlayerShot"))
        {
            //send out an alert
            //temp test: destroy gameobject
            Destroy(this.gameObject);
        }
    }
}
