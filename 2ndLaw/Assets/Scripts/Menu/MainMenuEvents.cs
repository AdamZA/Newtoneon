using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuEvents : MonoBehaviour
{
    private int _highScore;

    [SerializeField] private GameObject mainMenuText;
    [SerializeField] private GameObject playerButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button musicButton;

    [SerializeField] private Sprite musicUnmutedIcon;
    [SerializeField] private Sprite musicMutedIcon;
    [SerializeField] private Sprite soundMutedIcon;
    [SerializeField] private Sprite soundUnmutedIcon;

    [SerializeField] private AudioSource Music;

    public void Start()
    {
        var ingameMusic = GameObject.FindGameObjectWithTag("Music");
        if(ingameMusic != null)
        {
            Destroy(ingameMusic);
        }

        Music.mute = AudioSettings.MusicMuted;
        musicButton.image.sprite = AudioSettings.MusicMuted ? musicMutedIcon : musicUnmutedIcon;
        soundButton.image.sprite = AudioSettings.SoundMuted ? soundMutedIcon : soundUnmutedIcon;

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
        AutoFade.LoadScene("Game_Injector", 0.4f, 0.0f, Color.black);
    }

    public void MuteMusicPressed()
    {
        AudioSettings.SetMusicMuted(!AudioSettings.MusicMuted);
        Music.mute = AudioSettings.MusicMuted;
        musicButton.image.sprite = AudioSettings.MusicMuted ? musicMutedIcon : musicUnmutedIcon;
    }

    public void MuteSoundPressed()
    {
        AudioSettings.SetSoundMuted(!AudioSettings.SoundMuted);
        soundButton.image.sprite = AudioSettings.SoundMuted ? soundMutedIcon : soundUnmutedIcon;
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
