﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerManager))]
//[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(WeatherManager))]
[RequireComponent(typeof(AudioManager))]

public class Managers : MonoBehaviour
{
    public static AudioManager Audio { get; private set; }
    //public static PlayerManager Player { get; private set; }
    //public static InventoryManager Inventory { get; private set; }
    public static WeatherManager Weather { get; private set; }


    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Audio = GetComponent<AudioManager>();
        //Player = GetComponent<PlayerManager>();
        //Inventory = GetComponent<InventoryManager>();
        //Weather = GetComponent<WeatherManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Audio);
        //_startSequence.Add(Player);
        //_startSequence.Add(Inventory);
        //_startSequence.Add(Weather);

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

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                    numReady++;
            }

            if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);

            yield return null;
        }

        Debug.Log("All managers started");
    }
}
