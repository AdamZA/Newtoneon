using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    [SerializeField] private Transform shotPrefab;
    [SerializeField] private Transform orbObject;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private GameConfig config;
    public Transform playerObject;
    private float _remainingCooldown;
    private bool _onCooldown;
    private Rect _touchableScreen;
    private GameStateManager _manager;
    private bool _gunSafety;

    void Start()
    {
        _gunSafety = true;
        _remainingCooldown = config.shotCooldown;
        _onCooldown = false;
        _touchableScreen = new Rect(0, 0, Screen.width, Screen.height - 200);
        GameObject gsm = GameObject.FindGameObjectWithTag("GameStateManager");
        if (gsm != null) _manager = gsm.GetComponent<GameStateManager>();
        Invoke("RemoveSafety", config.gunSafetyDelay);
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
                _remainingCooldown = config.shotCooldown;
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
            if(_manager != null && _manager.soundMuted == 0)
            {
                AudioSource.PlayClipAtPoint(shotSound, gameObject.transform.position);
            }
            shot.GetComponent<Rigidbody2D>().velocity = targetDir * -config.shotSpeed;

            Recoil();
            _onCooldown = true;
        }
        
    }

    void RemoveSafety()
    {
        _gunSafety = false;
    }

    void Recoil()
    {
        var orbPos = orbObject.position;
        var playerPos = playerObject.position;
        Vector3 targetDir = playerPos - orbPos;
        playerObject.GetComponent<Rigidbody2D>().velocity = targetDir * config.playerRecoilSpeed;
    }

}
