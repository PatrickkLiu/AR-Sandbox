using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CoordinateRequest : MonoBehaviour
{
    // #1 create tag list
    GameObject[] sandToys;
    public Transform Plane;

    void Start()
    {       
        // #2 assign gameobjects to the list
        if (sandToys == null)
        sandToys = GameObject.FindGameObjectsWithTag("SandToy");
    }
    
    void FixedUpdate()
    {               
        // #3 hook coroutine with our json url
        StartCoroutine(GetRequest("http://127.0.0.1:5000/")); //lesson learned: don't try to do 'foreach' every frame 

    }
    

    IEnumerator GetRequest(string yoloURL)
    {
        Debug.Log("Getting Request.");
        
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
            

            // #7 Assign coordinate and Calibrate
            foreach (GameObject sandToy in sandToys)
            {
                JSONNode CoordX = coordinateInfo[sandToy.name][0]["x"];
                JSONNode CoordZ = coordinateInfo[sandToy.name][0]["y"]; 

                sandToy.transform.parent.position = new Vector3 (CoordX / 20 - 20F, 0, CoordZ / 20 - 1f);
            }

        }


    }


}