using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    [SerializeField] private AudioSource soundSrc;
    [SerializeField] private AudioSource music1Src;
    [SerializeField] private string introBMGMusic;
    [SerializeField] private string levelBMGMusic;

    private float _musicVolume;
    public float musicVolume
    {
        get { return _musicVolume; }
        set
        {
            _musicVolume = value;
            if(music1Src != null)
            {
                music1Src.volume = _musicVolume;
            }
        }
    }

    public bool musicMute
    {
        get
        {
            if(music1Src != null)
            {
                return music1Src.mute;
            }
            return false;
        }
        set
        {
            if(music1Src != null)
            {
                music1Src.mute = value;
            }
        }
    }

    public void PlayIntroMusic() {
        PlayMusic(Resources.Load("Music/" + introBMGMusic) as AudioClip);
    }

    public void PlayLevelMusicc()
    {
        PlayMusic(Resources.Load("Music/" + levelBMGMusic) as AudioClip);
    }

    private void PlayMusic(AudioClip clip)
    {
        music1Src.clip = clip;
        music1Src.Play();
    }

    public void StopMusic()
    {
        music1Src.Stop();
    }

    public void PlaySound(AudioClip clip)
    {
        soundSrc.PlayOneShot(clip);
    }

    public  float soundVolumn
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }
    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    public void Startup(NetworkService service)
    {
        Debug.Log("Audio Manager starting ...");
        _network = service;
        music1Src.ignoreListenerVolume = true;
        music1Src.ignoreListenerPause = true;
        soundVolumn = 1f;
        musicVolume = 1f;
        status = ManagerStatus.Started;
    }
}
