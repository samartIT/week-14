using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Light sun;

    private float _fullIntensity;
    private float _cloudValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _fullIntensity = sun.intensity;
    }

    private void update() {
        SetOvetcast(_cloudValue);
        _cloudValue += 0.005f;
    }

    private void SetOvercast(float value) {
        sky.setFloat("_Blend", value);
        sun.insensity = _fullIntensity - (_fullIntensity * value);
    }
}
