using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupUIManager : MonoBehaviour {

    public TMPro.TMP_Text sensitivityText;
    public Slider sensitivitySlider;

    public TMPro.TMP_Text soundButtonText;
    public TMPro.TMP_Text musicButtonText;

    private bool isSoundOn;
    private bool isMusicOn;

    void OnEnable() {
        loadPreferences();
        checkMusicButton();
        checkSoundButton();
    }

    private void OnDisable() {
        //savePreferences();
    }

    public void toggleMusicButton() {
        this.isMusicOn = !isMusicOn;
        checkMusicButton();
    }

    private void checkMusicButton() {
        if (this.isMusicOn) {
            musicButtonText.text = "Music: ON";
        } else {
            musicButtonText.text = "Music: OFF";
        }
    }

    public void toggleSoundButton() {
        this.isSoundOn = !isSoundOn;
        checkSoundButton();
    }

    private void checkSoundButton() {
        if (this.isSoundOn) {
            soundButtonText.text = "Sound: ON";
        } else {
            soundButtonText.text = "Sound: OFF";
        }
    }

    public void onSensitivitySliderValueChange() {
        double sliderValue = sensitivitySlider.value;
        sliderValue = System.Math.Round(sliderValue, 1);

        sensitivityText.text = "Sensitivity: " + sliderValue.ToString();
    }

    public void loadPreferences() {
        if (PlayerPrefs.HasKey(PrefKeys.MUSIC_IS_ON.ToString())) {
            if (PlayerPrefs.GetInt(PrefKeys.MUSIC_IS_ON.ToString()) == 1) {
                isMusicOn = true;
            }
        } else {
            isMusicOn = false;
        }

        if (PlayerPrefs.HasKey(PrefKeys.SOUND_IS_ON.ToString())) {
            if (PlayerPrefs.GetInt(PrefKeys.SOUND_IS_ON.ToString()) == 1) {
                isSoundOn = true;
            } 
        } else {
            isSoundOn = false;
        }

        if (PlayerPrefs.HasKey(PrefKeys.SENSITIVITY.ToString())) { 
            float sliderValue = PlayerPrefs.GetFloat(PrefKeys.SENSITIVITY.ToString());
            sensitivitySlider.value = sliderValue;
        }

    }

    public void savePreferences() {
        double sensitivitySliderValue = sensitivitySlider.value;
        sensitivitySliderValue = System.Math.Round(sensitivitySliderValue, 1);

        int isSoundOnInt;
        int isMusicOnInt;

        if (isSoundOn) {
            isSoundOnInt = 1;
        } else {
            isSoundOnInt = 0;
        }

        if (isMusicOn) {
            isMusicOnInt = 1;
        } else {
            isMusicOnInt = 0;
        }

        PlayerPrefs.SetFloat(PrefKeys.SENSITIVITY.ToString(), (float)sensitivitySliderValue);
        PlayerPrefs.SetInt(PrefKeys.SOUND_IS_ON.ToString(), isSoundOnInt);
        PlayerPrefs.SetInt(PrefKeys.MUSIC_IS_ON.ToString(), isMusicOnInt);

        PlayerPrefs.Save();
    }


}
