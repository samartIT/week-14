using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    public void Startup(NetworkService service) {
        Debug.Log ("Audio Manager starting ...");
        _network = service;
        status = ManagerStatus.Started;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
