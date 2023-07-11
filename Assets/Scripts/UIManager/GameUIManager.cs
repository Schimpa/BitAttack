using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour {

    public TMPro.TMP_Text scoreText;
    public Animation levelUpTextAnimation;
    public LevelUpTextBehaviour levelUpText;

    public void OnEnable() {
        resetUI();
    }

    public void setUIProperties(int score) {
        scoreText.text = score.ToString();
    }

    public void resetUI() {
        scoreText.text = "0";
        levelUpTextAnimation.Stop();
        levelUpTextAnimation.Rewind();
    }

    public void playLevelUpAnimation(int level) {
        levelUpText.playLevelUpAnimation(level);
    }

    public void playLevelUpEmptyAnimation() {
        levelUpText.playEmptyAnimation();
    }

}
