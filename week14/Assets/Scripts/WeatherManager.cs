using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;
    public void Startup(NetworkService service)
    {
        Debug.Log("Weather starting ... ");
        _network = service;
        StartCoroutine(_network.GetWeatherXML(OnXMLDataLoaded));
        status = ManagerStatus.Initializing;
    }
    public float cloundValue { get; private set;}
    public void OnXMLDataLoaded(string data)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;
        XmlNode node = root.SelectSingleNode("clouds");
        string value = node.Attributes["value"].Value;
        cloundValue = Convert.ToInt32(value) / 100f;
        Debug.Log("Value = " + cloundValue);
        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);

        status = ManagerStatus.Started;
    }
}
