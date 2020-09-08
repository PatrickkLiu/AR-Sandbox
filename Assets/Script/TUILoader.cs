using System.Collections;
using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Funly.SkyStudio;
using UnityEngine.Networking;
public class TUILoader : MonoBehaviour
{
    public GameObject CircleBackground;
    public Image Loading;
    public TUIrequest TUIListener;
    public int CircelIndex;

    public SkyProfile m_Profile;

    public AudioSource camAudio;
    public AudioSource envAudio;
    GameObject[] weatherAudios;

    //we define the skycontroller here so that it could be used under both of the function below 
    public TimeOfDayController skycontroller;
    
    private bool IsOpened = false;
    private bool CanClose = false;

    public float timer=0;
    public bool startTimer;

    public int TimeNeededToOpen=2;


    void Start()
    {       
        // #2 assign gameobjects to the list
        if (weatherAudios == null)
        weatherAudios = GameObject.FindGameObjectsWithTag("Sound");
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
        }
    }

	void FixedUpdate () {
        
        Loading.fillAmount = timer / TimeNeededToOpen;
        if (IsOpened) Loading.fillAmount = 1;

        if (startTimer)
        {
            timer += Time.deltaTime;
        }

        if (timer >= TimeNeededToOpen)
        {
            if (CircelIndex!=6) {
                skycontroller.skyProfile = m_Profile;
                foreach (GameObject weatherAudio in weatherAudios) {
                    AudioSource audio = weatherAudio.GetComponent<AudioSource>();
                    if (audio != null) audio.Stop();
                }
                if (envAudio != null) envAudio.Play();
            }     

            IsOpened = true;
            startTimer = false;
            timer = 0;

            if (CircelIndex==6) {
                camAudio.Play(0);
                StartCoroutine(GetRequest("http://127.0.0.1:5000/Cap"));
                Debug.Log("Caped");
            }

      
        }

        if (TUIListener.currentBox != CircelIndex && !(CircelIndex==6 && TUIListener.cap))
        {
            startTimer = false;
            IsOpened = false;
            timer = 0;
            CircleBackground.SetActive(false);
        }

        if ((TUIListener.currentBox == CircelIndex || (CircelIndex==6 && TUIListener.cap)) && IsOpened == false)
        {
            startTimer = true;
            CircleBackground.SetActive(true);
        }

    }

}
