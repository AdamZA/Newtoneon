using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static event Action OnGameOver;

    public float enemyStartSpeed;
    private InGameMenu _inGameMenu;
    private EnemySpawner _enemySpawner;
    private ScoreManager _scoreManager;

    public int soundMuted => AudioSettings.SoundMuted ? 1 : 0;
    public int musicMuted => AudioSettings.MusicMuted ? 1 : 0;

    void Start()
    {
        Application.targetFrameRate = 60;

        GameObject eventManager = GameObject.FindGameObjectWithTag("EventSystem");
        if (eventManager != null)
            _inGameMenu = eventManager.GetComponent<InGameMenu>();

        GameObject spawnerObject = GameObject.FindGameObjectWithTag("SpawnerContainer");
        if (spawnerObject != null)
            _enemySpawner = spawnerObject.GetComponent<EnemySpawner>();

        GameObject scoreManagerObject = GameObject.FindGameObjectWithTag("ScoreManager");
        if (scoreManagerObject != null)
            _scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    public void GameOver()
    {
        if (_inGameMenu != null) _inGameMenu.GameOver();
        if (_enemySpawner != null) _enemySpawner.playerAlive = false;
        if (_scoreManager != null) _scoreManager.GameOver();
        OnGameOver?.Invoke();
    }
}
