using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService
{
    private const string xmlAPI = "http://api.openweathermap.org/data/2.5/weather?q=bangkok,th&mode=xml&APPID=f28ac29d58733b62581e9056b9db4936";

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.LogError("network problem : " + request.url);
            }else if (request.responseCode != (long)System.Net.HttpStatusCode.OK)
            {
                Debug.LogError("network problem : " + request.error);
            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlAPI, callback);
    }
}
