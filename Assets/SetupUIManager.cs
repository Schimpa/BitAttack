using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupUIManager : MonoBehaviour {

    public TMPro.TMP_Text sliderText;
    public Slider slider;

    public TMPro.TMP_Text soundButtonText;
    public TMPro.TMP_Text musicButtonText;

    private bool isSoundOn;
    private bool isMusicOn;

    void Start() {
        isSoundOn = true;
        isMusicOn = true;
    }

    void Update() {
        
    }

    public void toggleMusicButton() {
        this.isMusicOn = !isMusicOn;

        if (this.isMusicOn) {
            musicButtonText.text = "Music: ON";
        } else {
            musicButtonText.text = "Music: OFF";
        }
    }

    public void toggleSoundButton() {
        this.isSoundOn = !isSoundOn;

        if (this.isSoundOn) {
            soundButtonText.text = "Sound: ON";
        } else {
            soundButtonText.text = "Sound: OFF";
        }
    }

    public void onSensitivitySliderValueChange() {
        double sliderValue = slider.value;
        sliderValue = System.Math.Round(sliderValue, 1);

        sliderText.text = "Sensitivity: " + sliderValue.ToString();
    }

    public void savePreferences() {
        double sliderValue = slider.value;
        sliderValue = System.Math.Round(sliderValue, 1);

        int isSoundOnInt = 0;
        int isMusicOnInt = 0;

        if (isSoundOn) {
            isSoundOnInt = 1;
        }
        if (isMusicOn) {
            isMusicOnInt = 1;
        }

        PlayerPrefs.SetFloat(PrefKeys.SENSITIVITY.ToString(), (float)sliderValue);
        PlayerPrefs.SetInt(PrefKeys.SOUND_IS_ON.ToString(), isSoundOnInt);
        PlayerPrefs.SetInt(PrefKeys.MUSIC_IS_ON.ToString(), isMusicOnInt);

        PlayerPrefs.Save();
    }


}
