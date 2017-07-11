using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

    private bool _paused;
    private GameObject _player;
    private int _musicMuted;
    private int _soundMuted;
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

    public AudioSource Music;

    public GameStateManager gameStateManager;

    public void Start()
    {
        _paused = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        _musicMuted = PlayerPrefs.GetInt("music", 0);
        _soundMuted = PlayerPrefs.GetInt("sounds", 0);

        if (_musicMuted == 0)
        {
            musicButton.image.sprite = musicUnmutedIcon;
            Music.mute = false;
        }
        else
        {
            musicButton.image.sprite = musicMutedIcon;
            Music.mute = true;
        }

        if (_soundMuted == 0)
        {
            soundButton.image.sprite = soundUnmutedIcon;
        }
        else
        {
            soundButton.image.sprite = soundMutedIcon;
        }
    }

    public void RestartGame()
    {
        AutoFade.LoadScene("Game_Main", 0.5f, 0.1f, Color.black);
        Time.timeScale = 1;
    }

    public void BackButton()
    {
        AutoFade.LoadScene("Game_Menu", 0.5f, 0.5f, Color.black);
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

    public void MuteMusicPressed()
    {
        if(_musicMuted == 0)
        {
            _musicMuted = 1;
            PlayerPrefs.SetInt("music", 1);
            gameStateManager.musicMuted = 1;
            musicButton.image.sprite = musicMutedIcon;
            Music.mute = true;
        }
        else
        {
            _musicMuted = 0;
            PlayerPrefs.SetInt("music", 0);
            gameStateManager.musicMuted = 0;
            musicButton.image.sprite = musicUnmutedIcon;
            Music.mute = false;
        }
    }

    public void MuteSoundPressed()
    {
        if(_soundMuted == 0)
        {
            _soundMuted = 1;
            PlayerPrefs.SetInt("sounds", 1);
            gameStateManager.soundMuted = 1;
            soundButton.image.sprite = soundMutedIcon;
           
        }
        else
        {
            _soundMuted = 0;
            PlayerPrefs.SetInt("sounds", 0);
            gameStateManager.soundMuted = 0;
            soundButton.image.sprite = soundUnmutedIcon;
            
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
