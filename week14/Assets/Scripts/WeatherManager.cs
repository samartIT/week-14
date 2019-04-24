using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private NetWorkService _network;

    public void Startup(NetWorkService service)
    {
        Debug.Log("Weather starting ... ");
        _network = service;
        status = ManagerStatus.Started;
    }
}
