using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip musicPreloop;
    public AudioClip musicLoop;
    private AudioSource _musicPlayer;

    void Start()
    {
        _musicPlayer = GetComponent<AudioSource>();
        _musicPlayer.loop = false;
        StartCoroutine(playInitial());
    }

    IEnumerator playInitial()
    {
        Debug.Log("playing initial");
        _musicPlayer.clip = musicPreloop;
        _musicPlayer.Play();
        yield return new WaitForSeconds(_musicPlayer.clip.length);

        StartCoroutine(playLoop());
    }

    IEnumerator playLoop()
    {
        Debug.Log("playing loop");
        _musicPlayer.clip = musicLoop;
        _musicPlayer.loop = true;
        _musicPlayer.Play();
        yield return new WaitForSeconds(_musicPlayer.clip.length);
        StartCoroutine(playLoop());
    }
}


