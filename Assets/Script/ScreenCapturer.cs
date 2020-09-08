using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCapturer : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentScreen = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ScreenCapture.CaptureScreenshot("Screenshot" + (currentScreen++) + ".png");
            ScreenCapture.CaptureScreenshot("1");
            Debug.Log(Application.persistentDataPath);
        }

    }
}
