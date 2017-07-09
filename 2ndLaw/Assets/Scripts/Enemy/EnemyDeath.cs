using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GameObject _scoreManager;
    public ParticleSystem deathAnimation;
    public void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("PlayerShot"))
        {
            if(_scoreManager != null)
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
