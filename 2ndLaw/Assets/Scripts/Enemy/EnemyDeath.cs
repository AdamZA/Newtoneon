using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathAnimation;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameConfig config;
    private GameObject _scoreManager;
    private GameStateManager _gameStateManager;

    public void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        GameObject gsm = GameObject.FindGameObjectWithTag("GameStateManager");
        if (gsm != null) _gameStateManager = gsm.GetComponent<GameStateManager>();
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("PlayerShot"))
        {
            if (_gameStateManager != null && _gameStateManager.soundMuted == 0)
            {
                AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);
            }

            if (_scoreManager != null)
            {
                _scoreManager.GetComponent<ScoreManager>().incrementScore(config != null ? config.killScore : 50);
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
