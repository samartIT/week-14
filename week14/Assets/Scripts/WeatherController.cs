using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Light sun;

    private float _fullintensity;

    void Awake() { 
        Messenger.AddListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated); //Update()
    }

    void OnDestroy() {
        Messenger.RemoveListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated); //Update()
    }
    
    void Start()
    {
        _fullintensity = sun.intensity;    
    }

    void OnWeatherUpdated() {
        SetOvercast(Managers.Weather.cloudValue); //Update()
    }

    
    private void SetOvercast(float value) {
        sky.SetFloat("_Blend", value);
        sun.intensity = _fullintensity - (_fullintensity * value);
    }
}
