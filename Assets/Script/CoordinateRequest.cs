using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CoordinateRequest : MonoBehaviour
{
    // #1 create tag list
    GameObject[] sandToys;

    void Start()
    {       
        // #2 assign gameobjects to the list
        if (sandToys == null)
        sandToys = GameObject.FindGameObjectsWithTag("SandToy");
    }

    void Update()
    {               
        // #3 hook coroutine with our json url and target gameobjects
        foreach (GameObject sandToy in sandToys)
        {
            StartCoroutine(GetRequest("http://127.0.0.1:5000/", sandToy.name, sandToy.transform));
        }
    }

    IEnumerator GetRequest(string yoloURL,string toyName, Transform toyTransform)
    {
        
        using (UnityWebRequest coordinateRequest = UnityWebRequest.Get(yoloURL))  
        {
            // #4 Request and wait for the desired page
            yield return coordinateRequest.SendWebRequest();                  

            // #5 Return error if there's any
            if (coordinateRequest.isNetworkError || coordinateRequest.isHttpError)
            {
                Debug.LogError(coordinateRequest.error);
                yield break;
            }
                                                                                         
            //<Print all coordinates>
            //Debug.Log(coordinateRequest.downloadHandler.text);

            // #6 Parsing
            JSONNode coordinateInfo = JSON.Parse(coordinateRequest.downloadHandler.text);
            JSONNode CoordX = coordinateInfo[toyName][0]["x"];
            JSONNode CoordZ = coordinateInfo[toyName][0]["y"];
            //print(CoordX);

            // #7 Assign coordinate and Calibrate
            toyTransform.position = new Vector3 (CoordZ / 4 + 25F, -1.5f, CoordX / 6);

            /*JSONNode CoordX = coordinateInfo[toyName]["x"];
             *JSONNode CoordZ = coordinateInfo[toyName]["y"];
             * 
             * 
             * 
             */
        }


    }




}