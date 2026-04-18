using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameConfig config;
    private int _score;
    private int _highScore;
    private bool _gameOver;
    private GameObject _gameStateManager;

    public void Start()
    {
        _gameStateManager = GameObject.FindGameObjectWithTag("GameStateManager");
        _score = 0;
        _gameOver = false;
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void incrementScore(int increaseAmount)
    {
        if (!_gameOver)
        {
            _score += increaseAmount;
            scoreText.GetComponent<UnityEngine.UI.Text>().text = "SCORE: " + _score;

            if (_score % config.scorePerSpeedStep == 0 && _gameStateManager != null)
            {
                GameStateManager manager = _gameStateManager.GetComponent<GameStateManager>();
                if (manager != null && manager.enemyStartSpeed < config.enemySpeedCap)
                {
                    manager.enemyStartSpeed += config.enemySpeedIncrement;
                }
            }
        }
    }

    public void GameOver()
    {
        _gameOver = true;
        if (_score > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", _score);
            PlayerPrefs.Save();
        }
    }
}
