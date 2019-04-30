using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;

    public float soundVolumn
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }
    public bool soundMute
    {
        get{ return AudioListener.pause; }
        set{ AudioListener.pause = value; }
    }
    public void Startup(NetworkService service)
    {
        Debug.Log("Audio Manager starting ...");
        _network = service;
        soundVolumn = 1f;
        status = ManagerStatus.Started;
    }
}
