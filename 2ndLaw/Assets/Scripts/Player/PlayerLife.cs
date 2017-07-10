using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public ParticleSystem deathAnimation;
    private GameStateManager _gameStateManager;
    public AudioClip deathSound;

    public void Start()
    {
        _gameStateManager = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag ("Death"))
        {
            if(_gameStateManager != null)
            {
                _gameStateManager.GameOver();
            }

            if (_gameStateManager.soundMuted == 0)
            {
                AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);
            }

            Instantiate(deathAnimation, transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
