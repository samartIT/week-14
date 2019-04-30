using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;

    [SerializeField] private AudioSource soundSrc;
    [SerializeField] private AudioSource music1Src;
    [SerializeField] private string introBGMusic;
    [SerializeField] private string levelBGMusic;

    public void PlayIntroMusic()
    {
        PlayMusic(Resources.Load("music/" + introBGMusic) as AudioClip);
    }

    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load("Music/" + levelBGMusic) as AudioClip);
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

    public float soundVolumn
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
        Debug.Log("Audio Managet starting ...");
        _network = service;
        soundVolumn = 1f;
        status = ManagerStatus.Started;
    }
}
