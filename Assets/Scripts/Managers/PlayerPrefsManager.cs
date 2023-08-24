using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {
    public void Start() {
        initPlayerPrefs();
    }
    public void initPlayerPrefs() {
        if (PlayerPrefs.HasKey(PrefKeys.MUSIC_IS_ON.ToString()) == false) {
            PlayerPrefs.SetInt(PrefKeys.MUSIC_IS_ON.ToString(), 1);
        }

        if (PlayerPrefs.HasKey(PrefKeys.SOUND_IS_ON.ToString()) == false) {
            PlayerPrefs.SetInt(PrefKeys.SOUND_IS_ON.ToString(), 1);
        }

        if (PlayerPrefs.HasKey(PrefKeys.SENSITIVITY.ToString()) == false) {
            PlayerPrefs.SetFloat(PrefKeys.SENSITIVITY.ToString(), 1);
        }

        if (PlayerPrefs.HasKey(PrefKeys.SCREEN_WIDTH.ToString()) == false) {
            PlayerPrefs.SetInt(PrefKeys.SCREEN_WIDTH.ToString(), Screen.currentResolution.width);
        }

        if (PlayerPrefs.HasKey(PrefKeys.SCREEN_HEIGHT.ToString()) == false) {
            PlayerPrefs.SetInt(PrefKeys.SCREEN_HEIGHT.ToString(), Screen.currentResolution.height);
        }

        if (PlayerPrefs.HasKey(PrefKeys.FULLSCREEN.ToString()) == false) {
            PlayerPrefs.SetInt(PrefKeys.FULLSCREEN.ToString(), 1);
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
    JOYSTICK_THRESOLD,
    SCREEN_WIDTH,
    SCREEN_HEIGHT,
    FULLSCREEN
}

public enum ArcadeKeys {
    SPAWN_INTERVAL,
    SPAWN_INTERVAL_MULTIPLIER,
    BIT_SPEED,
    BIT_SPEED_MULTIPLIER,
    LEVEL_DURATION
}
