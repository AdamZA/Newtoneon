using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GameObject _scoreManager;
    public ParticleSystem deathAnimation;
    private GameStateManager _gameStateManager;
    public AudioClip deathSound;

    public void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        _gameStateManager = GameObject.FindGameObjectWithTag("GameStateManager").GetComponent<GameStateManager>();
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("PlayerShot"))
        {
            if (_gameStateManager.soundMuted == 0)
            {
                AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);
            }

            if (_scoreManager != null)
            {
                _scoreManager.GetComponent<ScoreManager>().incrementScore(50);
                Instantiate(deathAnimation, transform.position, gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
            else
            {
                Instantiate(deathAnimation, transform.position, gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
            
            
        }
    }
}
