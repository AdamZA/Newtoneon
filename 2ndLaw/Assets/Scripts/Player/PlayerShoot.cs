using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    //variables/refs

    public Transform shotPrefab;
    public Transform playerObject;
    public Transform orbObject;
    public AudioClip shotSound;
    private float shotSpeed;
    private float _playerSpeed;
    private float _remainingCooldown;
    private float _baseCoolDown;
    private bool _onCooldown;
    private Rect _touchableScreen;
    private GameStateManager _manager;
    private bool _gunSafety;

    // Use this for initialization
    void Start ()
    {
        _gunSafety = true;
        shotSpeed = 8.0f;
        _playerSpeed = 5.0f;
        _baseCoolDown = 0.2f;
        _remainingCooldown = _baseCoolDown;
        _onCooldown = false;
        _touchableScreen = new Rect(0, 0, Screen.width, Screen.height - 200);
        _manager = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();
        Invoke("RemoveSafety", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_onCooldown)
        {
            _remainingCooldown -= Time.deltaTime;
            if (_remainingCooldown <= 0)
            {
                _onCooldown = false;
                _remainingCooldown = _baseCoolDown;
            }
        }

        //PC controls
        if (Input.GetKeyDown("space"))
        {
            Fire();
        }

        //Touch Controls
        for (int i = 0; i < Input.touchCount; i++)
        {
            TouchPhase phase = Input.GetTouch(i).phase;
            var touchPos = Input.GetTouch(i).position;

            if (_touchableScreen.Contains(touchPos) && phase == TouchPhase.Began)
            {
                Fire();
            }
        }
    }

    //Method for shot
    void Fire()
    {
        if(!_onCooldown && Time.timeScale != 0 && !_gunSafety)
        {
            //Calculate the angle
            var orbPos = orbObject.position;
            var playerPos = playerObject.position;
            Vector3 targetDir = playerPos - orbPos;
            var shot = Instantiate(shotPrefab, orbPos, Quaternion.identity);
            //TODO: Fix sound management
            if(_manager.soundMuted == 0)
            {
                AudioSource.PlayClipAtPoint(shotSound, gameObject.transform.position);
            }
            shot.GetComponent<Rigidbody2D>().velocity = targetDir * -shotSpeed;

            Recoil();
            _onCooldown = true;
        }
        
    }

    void RemoveSafety()
    {
        _gunSafety = false;
    }

    //Method for resultant movement
    void Recoil()
    {
        //Calculate the angle
        var orbPos = orbObject.position;
        var playerPos = playerObject.position;
        Vector3 targetDir = playerPos - orbPos;
        playerObject.GetComponent<Rigidbody2D>().velocity = targetDir * _playerSpeed;
    }

}
