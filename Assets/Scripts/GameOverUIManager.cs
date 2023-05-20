using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIManager : MonoBehaviour {

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text timeText;
    public TMPro.TMP_Text levelText;

    public void setGameStats(int score, int time, int level) {
        scoreText.text = score.ToString();
        timeText.text = TimeUtil.secondsToMinuteString(time);
        levelText.text = level.ToString();
    }
    public void onBackButton() {

    }
}
