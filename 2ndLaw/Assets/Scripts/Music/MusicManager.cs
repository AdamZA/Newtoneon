using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip musicPreloop;
    public AudioClip musicLoop;
    private AudioSource _source;
    private bool _secondStarted;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.loop = false;
        _source.clip = musicPreloop;
        _source.Play();
    }

    public void Update()
    {
        if(!_secondStarted && !_source.isPlaying)
        {
            _secondStarted = true;
            _source.loop = true;
            _source.clip = musicLoop;
            _source.Play();
        }
    }
}

