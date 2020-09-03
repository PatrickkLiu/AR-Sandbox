using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CoordinateRequestOld : MonoBehaviour
{
    /*
    [Header("Testing")]
    public Transform TestCube;

    [Header("Plant")]
    public Transform AppleTree;
    public Transform Cypress;
    public Transform PlainTree;
    public Transform Fir;
    public Transform BushA;
    public Transform BushB;
    public Transform PineTree;
    public Transform GrassLand;
    public Transform CoconutTree;

    [Header("Stone")]
    public Transform GreenStone;
    public Transform WhiteStone;
    public Transform Shell;
    public Transform Mermaid;

    [Header("Animals")]
    public Transform Tyrannosaurus;
    public Transform Triceratops;
    public Transform Bear;
    public Transform Parrot;
    public Transform Owl;
    public Transform Turtle;
    public Transform FishYellow;
    public Transform FishRed;
    public Transform FishBlue;
    public Transform Minny;
    public Transform PolarBear;
    public Transform Snake;
    public Transform Cat;
    public Transform Dog;

    [Header("Mankind")]
    public Transform Casual;
    public Transform Suit;
    public Transform Dad;
    public Transform Mom;
    public Transform OldLady;
    public Transform MidageLady;
    public Transform YoungLady;
    public Transform Santa;
    public Transform OldMan;
    public Transform Boy;

    [Header("Death")]
    public Transform Skull;
    public Transform Cross;
    public Transform Bone;
    public Transform Demon;
    public Transform Zombie;

    [Header("Religious")]
    [Header("Vehicles")]
    [Header("Items")]
    [Header("Food")]
    [Header("War")]
    [Header("Architecture")]
    */
    public GameObject[] sandToys;

    void Start()
    {
        if (sandToys == null)
        sandToys = GameObject.FindGameObjectsWithTag("SandToy");
    }

    void Update()
    {
        // #1 create tag array/ import array file
        
        // #2 Link to our YOLO json website and assign tags
        
        //For tag in tags
        foreach (GameObject sandToy in sandToys)
        StartCoroutine(GetRequest("http://127.0.0.1:5000/", sandToy.name,sandToy.transform));

        //StartCoroutine(GetRequest("http://127.0.0.1:5000/", "coordinate",TestCube));
    }



    IEnumerator GetRequest(string yoloURL,string toyName, Transform toyModel)
    {
        
        using (UnityWebRequest coordinateRequest = UnityWebRequest.Get(yoloURL))  
        {
            // #3 Request and wait for the desired page

            yield return coordinateRequest.SendWebRequest();                  

            // #4 Return error if there's any

            if (coordinateRequest.isNetworkError || coordinateRequest.isHttpError)
            {
                Debug.LogError(coordinateRequest.error);
                yield break;
            }
                                                                                         
            //<Print all coordinates>

            //Debug.Log(coordinateRequest.downloadHandler.text);


            // #5 Try to parse

            JSONNode coordinateInfo = JSON.Parse(coordinateRequest.downloadHandler.text);
            JSONNode CoordX = coordinateInfo[0][toyName]["x"];
            JSONNode CoordZ = coordinateInfo[0][toyName]["y"];
            //print(CoordX);

            // #6 
            toyModel.position = new Vector3 (CoordZ / 4 + 25F, -1.5f, CoordX / 6);

            /*JSONNode CoordX = coordinateInfo[toyName]["x"];
             *JSONNode CoordZ = coordinateInfo[toyName]["y"];
             * 
             * 
             * 
             */
        }


    }




}