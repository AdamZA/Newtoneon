using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

    private bool _paused;
    private GameObject _player;
    public bool playerDead;
   
    public Button pauseButton;
    public Button backButton;
    public Button soundButton;
    public Button musicButton;
    public Button restartButton;

    public GameObject pauseOverlay;
    public GameObject pausedText;
    public GameObject gameOverText;

    public Sprite playIcon;
    public Sprite pauseIcon;
    public Sprite musicUnmutedIcon;
    public Sprite musicMutedIcon;
    public Sprite soundMutedIcon;
    public Sprite soundUnmutedIcon;

    public void Start()
    {
        _paused = false;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void RestartGame()
    {
        AutoFade.LoadScene("Game_Main", 1, 1, Color.black);
        Time.timeScale = 1;
    }

    public void BackButton()
    {
        AutoFade.LoadScene("Game_Menu", 1, 1, Color.black);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {

        if (_paused == false)
        {
            if(_player != null)
            {
                _player.GetComponent<PlayerRotation>().isPaused = true;
            }
            Time.timeScale = 0;
            pausedText.SetActive(true);
            pauseButton.image.sprite = playIcon;
            pauseOverlay.SetActive(true);
            _paused = true;
            ShowButtons(true);
        }
        else
        {
            if (_player != null)
            {
                _player.GetComponent<PlayerRotation>().isPaused = false;
            }
            Time.timeScale = 1;
            pausedText.SetActive(false);
            pauseButton.image.sprite = pauseIcon;
            pauseOverlay.SetActive(false);
            _paused = false;
            ShowButtons(false);
        }
    }

    public void ShowButtons(bool toggle)
    {
        if(toggle)
        {
            backButton.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            musicButton.gameObject.SetActive(true);
            soundButton.gameObject.SetActive(true);
        }
        else
        {
            backButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
            musicButton.gameObject.SetActive(false);
            soundButton.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        ShowButtons(true);
        pauseOverlay.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        gameOverText.SetActive(true);
    }
}
