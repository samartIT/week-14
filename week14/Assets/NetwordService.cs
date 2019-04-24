using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetwordService : MonoBehaviour
{
private const string xmlAPI = "http://api.openweathermap.org/data/2.5/weather?q=bangkok,th&mode=xml&APPID={f4d6e0abff0c7171d85e0c4b37aad6a9}";

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.LogError("network problem : " + request.error);
            }
            else if(request.responseCode != (long)System.Net.HttpStatusCode.OK)
        }else{
            callback(AssetBundleCreateRequest.downloadHandler.text);
        }
    }
    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlAPI, callback);
    }
}
