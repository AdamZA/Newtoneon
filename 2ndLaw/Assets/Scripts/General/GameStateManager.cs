using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public float enemyStartSpeed;
    private InGameMenu _inGameMenu;
    private EnemySpawner _enemySpawner;
    private ScoreManager _scoreManager;
    public int soundMuted;
    public int musicMuted;

    void Start ()
    {
        soundMuted = PlayerPrefs.GetInt("sounds", 0);
        musicMuted = PlayerPrefs.GetInt("music", 0);

        GameObject _eventManager = GameObject.FindGameObjectWithTag("EventSystem");
        if(_eventManager != null)
        {
            _inGameMenu = _eventManager.GetComponent<InGameMenu>();
        }

        GameObject _enemySpawnerObject = GameObject.FindGameObjectWithTag("SpawnerContainer");
        if (_enemySpawnerObject != null)
        {
            _enemySpawner = _enemySpawnerObject.GetComponent<EnemySpawner>();
        }

        GameObject _scoreManagerObject = GameObject.FindGameObjectWithTag("ScoreManager");
        if(_scoreManagerObject != null)
        {
            _scoreManager = _scoreManagerObject.GetComponent<ScoreManager>();
        }
    }
	
    public void GameOver()
    {
        _inGameMenu.GameOver();
        _enemySpawner.playerAlive = false;
        _scoreManager.GameOver();
    }
	
}
