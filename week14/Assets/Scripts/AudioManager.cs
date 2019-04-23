using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField] private AudioSource soundSrc;
    [SerializeField] private AudioSource music1Src;
    [SerializeField] private AudioSource music2Src;
    [SerializeField] private string introBGMusic;
    [SerializeField] private string levelBGMusic;

    private AudioSource _activeMusic;
    private AudioSource _inactiveMusic;

    public float crossFadingRate = 1.5f;
    private bool _crossFading;

    public void PlayIntroMusic()
    {
        PlayMusic(Resources.Load("Music/" + introBGMusic) as AudioClip);
    }

    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load("Music/" + levelBGMusic) as AudioClip);
    }

    public void PlayMusic(AudioClip clip)
    {
        //music1Src.clip = clip;
        //music1Src.Play();
        if (_crossFading) { return; }
        StartCoroutine(CrossFadingMusic(clip));
    }

    public void StopMusic()
    {
        //music1Src.Stop();
        _activeMusic.Stop();
        _inactiveMusic.Stop();
    }

    private IEnumerator CrossFadingMusic(AudioClip clip)
    {
        _crossFading = true;
        _inactiveMusic.clip = clip;
        _inactiveMusic.volume = 0;
        _inactiveMusic.Play();

        float scaleRate = crossFadingRate * _musicVolume;
        while(_activeMusic.volume > 0)
        {
            _activeMusic.volume -= scaleRate * Time.deltaTime;
            _inactiveMusic.volume += scaleRate * Time.deltaTime;
            yield return null;
        }

        AudioSource tmp = _activeMusic;
        _activeMusic = _inactiveMusic;
        _activeMusic.volume = _musicVolume;

        _inactiveMusic = tmp;
        _inactiveMusic.Stop();
        _crossFading = false;
    }

    public ManagerStatus status { get; private set; }
    private NetworkService _network;

    public void PlaySound(AudioClip clip)
    {
        soundSrc.PlayOneShot(clip);
    }

    public void Startup(NetworkService service)
    {
        Debug.Log("Audio manager starting ...");
        _network = service;
        status = ManagerStatus.Started;
        music1Src.ignoreListenerVolume = true;
        music1Src.ignoreListenerPause = true;
        music2Src.ignoreListenerVolume = true;
        music2Src.ignoreListenerPause = true;
        soundVolume = 1f;
        musicVolume = 1f;

        _activeMusic = music1Src;
        _inactiveMusic = music2Src;
    }

    public float soundVolume
    {
        get
        {
            return AudioListener.volume;
        }
        set
        {
            AudioListener.volume = value;
        }
    }

    public bool soundMute
    {
        get
        {
            return AudioListener.pause;
        }
        set
        {
            AudioListener.pause = value;
        }
    }

    private float _musicVolume;
    public float musicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {
            _musicVolume = value;
            if (music1Src != null && !_crossFading)
            {
                music1Src.volume = _musicVolume;
                music2Src.volume = _musicVolume;
            }
        }
    }

    public bool musicMute
    {
        get
        {
            if (music1Src != null)
            {
                return music1Src.mute;
            }
            return false;
        }

        set
        {
            if (music1Src != null)
            {
                music1Src.mute = value;
                music2Src.mute = value;
            }
        }
    }
}
