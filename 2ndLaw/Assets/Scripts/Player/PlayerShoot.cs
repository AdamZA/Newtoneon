using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    //variables/refs

    public Transform shotPrefab;
    public Transform playerObject;
    public Transform orbObject;
    private float shotSpeed;
    private float playerSpeed;
    private float remainingCooldown;
    private float baseCoolDown;
    private bool onCooldown;

    // Use this for initialization
    void Start ()
    {
        shotSpeed = 8.0f;
        playerSpeed = 5.0f;
        baseCoolDown = 0.2f;
        remainingCooldown = baseCoolDown;
        onCooldown = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(onCooldown)
        {
            remainingCooldown -= Time.deltaTime;
            if(remainingCooldown <= 0)
            {
                onCooldown = false;
                remainingCooldown = baseCoolDown;
            }
        }

		//PC controls
        if(Input.GetKeyDown("space"))
        {
            Fire();
        }

        //Touch Controls
	}

    //Method for shot
    void Fire()
    {
        if(!onCooldown)
        {
            //Calculate the angle
            var orbPos = orbObject.position;
            var playerPos = playerObject.position;
            Vector3 targetDir = playerPos - orbPos;
            float angle = Vector3.Angle(targetDir, playerObject.forward);

            //Instantiate the shot
            var shot = Instantiate(shotPrefab, orbPos, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = targetDir * -shotSpeed;

            Recoil();
            onCooldown = true;
        }
        
    }


    //Method for resultant movement
    void Recoil()
    {
        //Calculate the angle
        var orbPos = orbObject.position;
        var playerPos = playerObject.position;
        Vector3 targetDir = playerPos - orbPos;
        playerObject.GetComponent<Rigidbody2D>().velocity = targetDir * playerSpeed;
    }

}
