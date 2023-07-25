using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUIManagerBase : MonoBehaviour {

    public TMPro.TMP_Text scoreText;
    public GameObject pauseButton;

    protected virtual void OnEnable() {
        resetUI();
        checkPauseButtonActivation();
    }

    private void checkPauseButtonActivation() {
        if (SystemInfo.deviceType == DeviceType.Handheld) {
            pauseButton.SetActive(true);
        } else {
            pauseButton.SetActive(false);
        }
    }

    public virtual void updateUIProperties(int score) {
        scoreText.text = score.ToString();
    }

    public virtual void resetUI() {
        scoreText.text = "0";
    }

}
