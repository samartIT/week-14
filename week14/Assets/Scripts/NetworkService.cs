using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService
{
private const string xmlAPI = "http://api.openweathermap.org/data/2.5/weather?q=bangkok,th&mode=xml&appid={2fd32fe1a7e75076b63a2608a2de1ef8}";
    
    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if(request.isNetworkError)
            {
                Debug.LogError("network problem : " + request.error);
            }
            else if (request.responseCode != (long)System.Net.HttpStatusCode.OK)
            {
                Debug.LogError("response error : " + request.responseCode);
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
