using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

    private bool _paused;
    private GameObject _player;
    public bool playerDead;
   
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button restartButton;

    [SerializeField] private GameObject pauseOverlay;
    [SerializeField] private GameObject pausedText;
    [SerializeField] private GameObject gameOverText;

    [SerializeField] private Sprite playIcon;
    [SerializeField] private Sprite pauseIcon;
    [SerializeField] private Sprite musicUnmutedIcon;
    [SerializeField] private Sprite musicMutedIcon;
    [SerializeField] private Sprite soundMutedIcon;
    [SerializeField] private Sprite soundUnmutedIcon;

    [SerializeField] private GameStateManager gameStateManager;

    private AudioSource _music;

    public void Start()
    {
        _paused = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        GameObject musicObj = GameObject.FindGameObjectWithTag("Music");
        if (musicObj != null) _music = musicObj.GetComponent<AudioSource>();

        if (_music != null) _music.mute = AudioSettings.MusicMuted;
        musicButton.image.sprite = AudioSettings.MusicMuted ? musicMutedIcon : musicUnmutedIcon;
        soundButton.image.sprite = AudioSettings.SoundMuted ? soundMutedIcon : soundUnmutedIcon;
    }

    public void RestartGame()
    {
        AutoFade.LoadScene("Game_Main", 0.2f, 0.1f, Color.black);
        Time.timeScale = 1;
    }

    public void BackButton()
    {
        AutoFade.LoadScene("Game_Menu", 0.2f, 0.1f, Color.black);
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
        AudioSettings.SetMusicMuted(!AudioSettings.MusicMuted);
        if (_music != null) _music.mute = AudioSettings.MusicMuted;
        musicButton.image.sprite = AudioSettings.MusicMuted ? musicMutedIcon : musicUnmutedIcon;
    }

    public void MuteSoundPressed()
    {
        AudioSettings.SetSoundMuted(!AudioSettings.SoundMuted);
        soundButton.image.sprite = AudioSettings.SoundMuted ? soundMutedIcon : soundUnmutedIcon;
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
