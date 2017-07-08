using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreText;
    private int _score;
    private int _highScore;
    private GameObject _gameStateManager;

    public void Start()
    {
        _gameStateManager = GameObject.FindGameObjectWithTag("GameStateManager");
        _score = 0;
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void incrementScore(int increaseAmount)
    {
        _score += increaseAmount;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + _score;

        if(_score % 500 == 0 && _gameStateManager != null)
        {
            GameStateManager manager = _gameStateManager.GetComponent<GameStateManager>();
            if(manager != null && manager.enemyStartSpeed < 4.0f)
            {
                _gameStateManager.GetComponent<GameStateManager>().enemyStartSpeed += 0.4f;
            }
            
        }
    }

    public void playerDead()
    {
        if (_score > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", _score);
            PlayerPrefs.Save();
        }
    }
}
