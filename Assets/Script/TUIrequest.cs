using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TUIrequest : MonoBehaviour
{
    public int currentBox=-1;
    // Start is called before the first frame update
    void Start()
    {
        currentBox=-1;
    }

    void Update()
    {               
        // #3 hook coroutine with our json url
        StartCoroutine(GetRequest("http://127.0.0.1:5001/")); //lesson learned: don't try to do 'foreach' every frame 

    }
    

    IEnumerator GetRequest(string TUIURL)
    {
        Debug.Log("Getting Request.");
        
        using (UnityWebRequest TUIRequest = UnityWebRequest.Get(TUIURL))  
        {
            // #4 Request and wait for the desired page
            yield return TUIRequest.SendWebRequest();                  

            // #5 Return error if there's any
            if (TUIRequest.isNetworkError || TUIRequest.isHttpError)
            {
                Debug.LogError(TUIRequest.error);
                yield break;
            }
                                                                                         
            //<Print all coordinates>
            //Debug.Log(TUIRequest.downloadHandler.text);

            // #6 Parsing
            JSONNode TUIInfo = JSON.Parse(TUIRequest.downloadHandler.text);
            currentBox = (int)TUIInfo[0];

            // #7 Assign coordinate and Calibrate


        }


    }
}
