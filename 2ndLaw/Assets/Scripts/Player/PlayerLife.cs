using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathAnimation;
    [SerializeField] private AudioClip deathSound;
    private GameStateManager _gameStateManager;

    public void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameStateManager");
        if (obj != null) _gameStateManager = obj.GetComponent<GameStateManager>();
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag ("Death"))
        {
            if(_gameStateManager != null)
            {
                _gameStateManager.GameOver();
            }

            if (_gameStateManager != null && _gameStateManager.soundMuted == 0)
            {
                AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);
            }

            Instantiate(deathAnimation, transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
