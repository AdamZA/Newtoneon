using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip initialMusic;
    public AudioClip loopMusic;
    private AudioSource _source;
    private float _delay;

	// Use this for initialization
	void Start ()
    {
        _source = GetComponent<AudioSource>();
        _delay = initialMusic.length;
        playMusic();
    }

    public void playMusic()
    {
        _source.clip = initialMusic;
        _source.Play();
        Invoke("transitionMusic", _delay);
    }

    private void transitionMusic()
    {
        _source.Stop();
        _source.clip = loopMusic;
        _source.loop = true;
        _source.Play();
    }
}
