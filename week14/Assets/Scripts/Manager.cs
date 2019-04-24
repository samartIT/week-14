using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(WeatherManager))]

public class Manager : MonoBehaviour
{
    public static WeatherManager Weather { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Weather = GetComponent<WeatherManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Weather);

        StartCoroutine(StartupManagers());
    }
    private IEnumerator StartupManagers()
    {
        NetworkService network = new NetworkService();

        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup(network);
        }

        yield return null;
        int numModules = _startSequence.Count;
        int numReady = 0;
    }
}

