using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleLoader : MonoBehaviour {

    // All assets in the pack are under CC licence and are forbidden to be resold.

    public GameObject WhatToOpen;
    public GameObject CircleBackground;
    public Image Loading;

    private bool IsOpened = false;
    private bool CanClose = false;

    private float timer;
    private bool startTimer;

    public int TimeNeededToOpen;

    // void Start() {
    //     startTimer = true;
    //     CircleBackground.SetActive(true);
    // }

	void Update () {

        Loading.fillAmount = timer / TimeNeededToOpen;

        if (startTimer)
        {
            timer += Time.deltaTime;
        }

        if (timer >= TimeNeededToOpen)
        {
            IsOpened = true;
            WhatToOpen.SetActive(true);
            startTimer = false;
            timer = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            startTimer = false;
            timer = 0;
            CircleBackground.SetActive(false);
        }

    }

    void OnTriggerEnter (Collider other) {
        if (IsOpened == false)
        {
            startTimer = true;
            CircleBackground.SetActive(true);
        }
    }

    void OnMouseOver()
    {
        if (CanClose == true)
        {
            IsOpened = false;
            CanClose = false;
        }

        if (Input.GetMouseButtonDown(0) && IsOpened == true)
        {
            CanClose = true;
            WhatToOpen.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && IsOpened == false)
        {
            startTimer = true;
            CircleBackground.SetActive(true);
        }
    }
}
