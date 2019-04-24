using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour , IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetwordService _network;
    // Start is called before the first frame update
    public void Startup(NetwordService service)
    {
        Debug.Log("Weather starting ...");
        _network = service;
        StartCoroutine (_network.GetWeatherXML (OnXMLDataLoaded));
        status = ManagerStatus.Initializing;
    }
    public void OnXMLDataLoaded(string data)
    {
        Debug.Log(data);
        status = ManagerStatus.Started;
    }

}
