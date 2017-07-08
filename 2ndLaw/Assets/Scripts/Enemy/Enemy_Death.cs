using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    private GameObject _scoreManager;

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
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            
        }
    }
}
