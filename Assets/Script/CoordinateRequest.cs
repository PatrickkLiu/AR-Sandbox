using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Http;

public class CoordinateRequest : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("https://www.example.com"));
    }

    IEnumerator GetRequest(string yoloURL)
    {
        
        using (UnityWebRequest coordinateRequest = UnityWebRequest.Get(yoloURL))  
        {
            // Request and wait for the desired page.
            yield return coordinateRequest.SendWebRequest();                  

            if (coordinateRequest.isNetworkError)
            {
                Debug.LogError(coordinateRequest.error);
                yield break;
            }

            //JSONNode coordinateInfo = JSON.Parse(coordinateRequest.downloadHandler.text);

        }
    }
}