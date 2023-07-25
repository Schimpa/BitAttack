using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    public void Start() {
        initPlayerPrefs();
    }
    public void initPlayerPrefs() {
        if (PlayerPrefs.HasKey(PrefKeys.MUSIC_IS_ON.ToString()) == false) {
            PlayerPrefs.SetInt(PrefKeys.MUSIC_IS_ON.ToString(), 0);
        }

        if (PlayerPrefs.HasKey(PrefKeys.SOUND_IS_ON.ToString()) == false) {
            PlayerPrefs.SetInt(PrefKeys.SOUND_IS_ON.ToString(), 0);
        }

        if (PlayerPrefs.HasKey(PrefKeys.SENSITIVITY.ToString()) == false) {
            PlayerPrefs.SetFloat(PrefKeys.SENSITIVITY.ToString(), 1);
        }

        PlayerPrefs.Save();
    }

    public void setSoundIsOn(bool value) {
        if (value == true) {
            PlayerPrefs.SetInt(PrefKeys.SOUND_IS_ON.ToString(), 1);
        } else {
            PlayerPrefs.SetInt(PrefKeys.SOUND_IS_ON.ToString(), 0);
        }
    }

    public void setMusicIsOn(bool value) {
        if (value == true) {
            PlayerPrefs.SetInt(PrefKeys.MUSIC_IS_ON.ToString(), 1);
        } else {
            PlayerPrefs.SetInt(PrefKeys.MUSIC_IS_ON.ToString(), 0);
        }
    }

    public void setSensitivity(float value) {
        PlayerPrefs.SetFloat(PrefKeys.SENSITIVITY.ToString(), value);
    }
}

public enum PrefKeys {
    MUSIC_IS_ON,
    SOUND_IS_ON,
    SENSITIVITY,
    JOYSTICK_THRESOLD
}
