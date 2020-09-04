using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TUILoader : MonoBehaviour
{
    public GameObject CircleBackground;
    public Image Loading;
    public TUIrequest TUIListener;
    public int CircelIndex;

    private bool IsOpened = false;
    private bool CanClose = false;

    public float timer=0;
    public bool startTimer;

    public int TimeNeededToOpen=2;

	void Update () {
        
        Loading.fillAmount = timer / TimeNeededToOpen;
        if (IsOpened) Loading.fillAmount = 1;

        if (startTimer)
        {
            timer += Time.deltaTime;
        }

        if (timer >= TimeNeededToOpen)
        {
            IsOpened = true;
            startTimer = false;
            timer = 0;
        }

        if (TUIListener.currentBox != CircelIndex)
        {
            startTimer = false;
            IsOpened = false;
            timer = 0;
            CircleBackground.SetActive(false);
        }

        if (TUIListener.currentBox == CircelIndex && IsOpened == false)
        {
            startTimer = true;
            CircleBackground.SetActive(true);
        }

    }

}
