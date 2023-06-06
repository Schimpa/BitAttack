using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour {

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text timeText;

    public void setUIProperties(int score, int time) {
        scoreText.text = score.ToString();
        timeText.text = time.ToString()+"s";
    }

    public void resetUI() {
        scoreText.text = "0";
        timeText.text = "0";
    }

}
