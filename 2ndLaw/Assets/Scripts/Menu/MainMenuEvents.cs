using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    private int _muteSounds;
    private int _muteMusic;
    private int _highScore;

    public GameObject mainMenuText;
    public GameObject playerButton;

    public void Start()
    {
        _muteSounds = PlayerPrefs.GetInt("sounds");
        _muteMusic = PlayerPrefs.GetInt("music");

        if (_muteMusic == 1)
        {
            //music.mute = true;
           // musicButton.image.sprite = musicIconOFF;
        }
        else
        {
            _muteMusic = 0;
            //music.Play();
        }
        if (_muteSounds == 1)
        {
            //music.mute = true;
            //soundButton.image.sprite = soundIconOFF;
        }
        else
        {
            _muteSounds = 0;
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

    public void MuteSoundButtonPressed()
    {
        ButtonPressEffect();
        if (PlayerPrefs.GetInt("Sounds") == 1)
        {
            PlayerPrefs.SetInt("Sounds", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Sounds", 1);
        }
    }

    public void MuteMusicButtonPressed()
    {
        ButtonPressEffect();
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
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
        if (_muteSounds == 0)
        {
        }
            
    }
	
}
