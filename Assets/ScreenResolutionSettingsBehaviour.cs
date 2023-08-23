using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolutionSettingsBehaviour : MonoBehaviour {

    public TMPro.TMP_Text resolutionText;
    public TMPro.TMP_Text fullScreenText;

    private List<Resolution> screenResolutions;

    private int resolutionArrayLength;
    private int currentSelection;

    private bool isFullScreen;

    void OnEnable() {
        screenResolutions = new List<Resolution>();
        isFullScreen = Screen.fullScreen;

        foreach (Resolution res in Screen.resolutions) {
            //Debug.Log(res.width + "x" + res.height + " : " + res.refreshRate + " aspect: " + (float)((float)res.width/(float)res.height) );
            bool isDuplicate = false;
            foreach (Resolution currentRes in screenResolutions) {               
                if ( (currentRes.width == res.width) && (currentRes.height == res.height)) {
                    isDuplicate = true;
                }
            }
            if (isDuplicate == false) {
                screenResolutions.Add(res);
            }
            
        }

        resolutionArrayLength = screenResolutions.Count;

        determineCurrentResolution();

        resolutionText.text = createResolutionsString();
        fullScreenText.text = createFullScreenString();


    }

    public void onResolutionButtonClick() {
        currentSelection++;

        if (currentSelection > (screenResolutions.Count - 1)) {
            currentSelection = 0;
        }

        resolutionText.text = createResolutionsString();
    }

    public void onFullScreenButtonClick() {
        isFullScreen = !isFullScreen;
        fullScreenText.text = createFullScreenString();
    }

    public void applySelectedResolution() {
        Resolution selectedRes = screenResolutions[currentSelection];
        Screen.SetResolution(selectedRes.width, selectedRes.height, isFullScreen);

        PlayerPrefs.SetInt(PrefKeys.SCREEN_WIDTH.ToString(), selectedRes.width);
        PlayerPrefs.SetInt(PrefKeys.SCREEN_HEIGHT.ToString(), selectedRes.height);

        if (isFullScreen) {
            PlayerPrefs.SetInt(PrefKeys.FULLSCREEN.ToString(), 1);
        } else {
            PlayerPrefs.SetInt(PrefKeys.FULLSCREEN.ToString(), 0);
        }
        
    }

    private void determineCurrentResolution() {
        Resolution currentRes = Screen.currentResolution;
        currentSelection = 0;

        foreach (Resolution res in screenResolutions) {
            if ( (res.width == currentRes.width) && (res.height == currentRes.height)) {
                return;
            } else {
                currentSelection++;
            }
        }
    }


    private string createResolutionsString() {
        Resolution selectedRes = screenResolutions[currentSelection];

        return selectedRes.width.ToString()+"x"+ selectedRes.height.ToString();
    }

    private string createFullScreenString() {
        if (isFullScreen == true) {
            return "Fullscreen: On";
        } else {
            return "Fullscreen: Off";
        }
    }
}
