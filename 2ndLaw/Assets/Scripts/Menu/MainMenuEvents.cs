using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuEvents : MonoBehaviour
{
    private int _musicMuted;
    private int _soundMuted;
    private int _highScore;

    public GameObject mainMenuText;
    public GameObject playerButton;
    public Button soundButton;
    public Button musicButton;

    public Sprite musicUnmutedIcon;
    public Sprite musicMutedIcon;
    public Sprite soundMutedIcon;
    public Sprite soundUnmutedIcon;

    public AudioSource Music;

    public void Start()
    {
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

        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        mainMenuText.GetComponent<UnityEngine.UI.Text>().text = "Highscore: " + _highScore;

    }   

    public void PlayButtonPressed()
    {
        ButtonPressEffect();
        playerButton.GetComponent<Animator>().SetTrigger("PlayPressed");
        Invoke("PlayButtonPressedSceneChange", 1);
    }

    public void PlayButtonPressedSceneChange()
    {
        AutoFade.LoadScene("Game_Main",0.4f, 0.1f, Color.black);
    }

    public void MuteMusicPressed()
    {
        if (_musicMuted == 0)
        {
            PlayerPrefs.SetInt("music", 1);
            _musicMuted = 1;
            Music.mute = true;
            musicButton.image.sprite = musicMutedIcon;
        }
        else
        {
            Music.mute = false;
            _musicMuted = 0;
            PlayerPrefs.SetInt("music", 0);
            musicButton.image.sprite = musicUnmutedIcon;
        }
    }

    public void MuteSoundPressed()
    {
        if (_soundMuted == 0)
        {
            _soundMuted = 1;
            PlayerPrefs.SetInt("sounds", 1);
            soundButton.image.sprite = soundMutedIcon;
        }
        else
        {
            _soundMuted = 0;
            PlayerPrefs.SetInt("sounds", 0);
            soundButton.image.sprite = soundUnmutedIcon;
        }
    }

    public void ClearScoreButtonPressed()
    {
        ButtonPressEffect();
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
    }

    public void ExitButtonPressed()
    {
        ButtonPressEffect();
        Application.Quit();
    }

    public void ButtonPressEffect()
    {
        
            
    }
	
}
