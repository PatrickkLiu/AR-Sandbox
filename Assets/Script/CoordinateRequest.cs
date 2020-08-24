using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Http;
using SimpleJSON;

public class CoordinateRequest : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("127.0.0.1:5000"));
    }

    IEnumerator GetRequest(string yoloURL)
    {
        
        using (UnityWebRequest coordinateRequest = UnityWebRequest.Get(yoloURL))  
        {
            // Request and wait for the desired page.
            yield return coordinateRequest.SendWebRequest();                  

            if (coordinateRequest.isNetworkError || coordinateRequest.isHttpError)
            {
                Debug.LogError(coordinateRequest.error);
                yield break;
            }

            JSONNode coordinateInfo = JSON.Parse(coordinateRequest.downloadHandler.text);
            string coordinate = coordinateInfo["coordinate"];
            Debug.Log(coordinate);

        }
    }


}