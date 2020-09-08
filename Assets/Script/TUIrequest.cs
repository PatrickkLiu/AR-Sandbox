using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TUIrequest : MonoBehaviour
{
    public int currentBox=-1;
    public bool cap=false;
    // Start is called before the first frame update
    void Start()
    {
        currentBox=-1;
    }

    void FixedUpdate()
    {               
        // #3 hook coroutine with our json url
        StartCoroutine(GetRequest("http://127.0.0.1:5000/TUI")); //lesson learned: don't try to do 'foreach' every frame 

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
            currentBox = (int)TUIInfo[0]-1;
            Debug.Log(((int)TUIInfo[0]).ToString());
            cap = false;
            if ((int)TUIInfo[1] == 7 || (int)TUIInfo[0] == 7) {
                cap = true;
            }
            // #7 Assign coordinate and Calibrate


        }


    }
}
