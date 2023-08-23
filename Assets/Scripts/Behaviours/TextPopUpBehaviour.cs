using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUpBehaviour : MonoBehaviour {

    [Header("Delay, after which the pop up appears.")]
    public float countDownDuration; // The delay in seconds, after which the pop up will appear
    public bool onlyOnFirstTime;    // The pop up will show only on first time at start of the game

    [SerializeField][Header("Delay, after which the pop up appears.")]
    private bool countDownActive;

    [Header("These Gameobjects will be activated and deactivated")]
    public GameObject[] childGameObjects;

    [Header("The continue button can be handled separately, for example by other functions")]
    public GameObject continueButton;
    [SerializeField] 
    private bool enableContinueButtonOnStart;

    private float countdownDurationTimer;
    private bool firstTimeActivated;


    private void OnEnable() {
        disablePopUpGameObjects();
        continueButton.SetActive(enableContinueButtonOnStart);
    }

    void Start() {
        firstTimeActivated = false;
        countdownDurationTimer = 0f;
    }

    // Update is called once per frame
    void Update() {
        handleCountDown();

        if (countdownDurationTimer >= countDownDuration && firstTimeActivated == false) {
            enablePopUpGameObjects();
            this.countDownActive = false;
        }

        if (Input.GetButtonDown("Submit")  && continueButton.activeSelf) {
            continueButton.GetComponent<Button>().onClick.Invoke();
        }

    }

    private void handleCountDown() {
        if (countDownActive) countdownDurationTimer += Time.deltaTime;
    }

    private void disablePopUpGameObjects() {
        foreach(GameObject obj in childGameObjects) {
            obj.gameObject.SetActive(false);
        }
    }

    private void enablePopUpGameObjects() {      
        foreach (GameObject obj in childGameObjects) {
            obj.gameObject.SetActive(true);
        }

        if (onlyOnFirstTime == true) {
            firstTimeActivated = true;
        }
    }


    public void finishAndResetPopUp() {
        //Finished and reset the pop up, so it can be triggered again when a new game starts
        resetPopUp();
        disablePopUpGameObjects();
        this.gameObject.SetActive(false);
    }

    public void resetPopUp() {
        countdownDurationTimer = 0f;
        disablePopUpGameObjects();
        continueButton.SetActive(enableContinueButtonOnStart);
    }

    public void startCountDown() {
        this.countDownActive = true;
    }

    public void enableContinueButton() {
        continueButton.SetActive(true);
    }



}
