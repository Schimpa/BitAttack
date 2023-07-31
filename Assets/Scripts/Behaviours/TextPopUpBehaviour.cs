using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopUpBehaviour : MonoBehaviour {

    public float delay; // The delay in seconds, after which the pop up will appear
    public bool onlyOnFirstTime;    // The pop up will show only on first time at start of the game

    private Transform[] childTransforms;
    private float timer;

    private bool firstTimeActivated;

    void Start() {
        childTransforms = this.gameObject.GetComponentsInChildren<Transform>();
        firstTimeActivated = false;
        timer = 0f;
        if (delay > 0f) {
            disablePopUpGameObjects();
        } else {
            Time.timeScale = 0f;
        }
        
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if (timer >= delay && firstTimeActivated == false) {
            enablePopUpGameObjects();
            Time.timeScale = 0f;
        }
    }

    private void disablePopUpGameObjects() {
        foreach(Transform obj in childTransforms) {
            obj.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(true);
    }

    private void enablePopUpGameObjects() {      
        foreach (Transform obj in childTransforms) {
            obj.gameObject.SetActive(true);
        }

        if (onlyOnFirstTime == true) {
            firstTimeActivated = true;
        }
    }


    public void finishAndResetPopUp() {
        //Finished and reset the pop up, so it can be triggered again when a new game starts
        Time.timeScale = 1f;
        resetTimer();
        disablePopUpGameObjects();
        this.gameObject.SetActive(false);
    }

    public void resetTimer() {
        timer = 0f;
    }
}
