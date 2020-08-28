using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CoordinateRequest : MonoBehaviour
{
    public Transform TestCube;

    void Update()
    {
        //Link to our YOLO json website
        StartCoroutine(GetRequest("http://127.0.0.1:5000/", "coordinate"));
    }



    IEnumerator GetRequest(string yoloURL,string toyName)
    {
        
        using (UnityWebRequest coordinateRequest = UnityWebRequest.Get(yoloURL))  
        {
            // Request and wait for the desired page.
            yield return coordinateRequest.SendWebRequest();                  

            // Return error if there's any
            if (coordinateRequest.isNetworkError || coordinateRequest.isHttpError)
            {
                Debug.LogError(coordinateRequest.error);
                yield break;
            }

            // Print all coordinates
            //Debug.Log(coordinateRequest.downloadHandler.text);


            // Try to parse
            JSONNode coordinateInfo = JSON.Parse(coordinateRequest.downloadHandler.text);
            JSONNode CoordX = coordinateInfo[0][toyName]["x"];
            JSONNode CoordZ = coordinateInfo[0][toyName]["y"];
            //print(CoordX);
            TestCube.position = new Vector3 (CoordZ / 4 + 25F, -1.5f, CoordX / 6);

            /*JSONNode CoordX = coordinateInfo[toyName]["x"];
             *JSONNode CoordZ = coordinateInfo[toyName]["y"];
             * 
             * 
             * 
             */
        }


    }




}