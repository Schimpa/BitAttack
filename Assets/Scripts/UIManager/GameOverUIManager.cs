using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour {

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text timeText;
    public TMPro.TMP_Text levelText;

    public void Awake() {
        adjustTextWidth();
    }

    public void setGameStats(int score, int time, int level) {
        scoreText.text = score.ToString();
        timeText.text = time.ToString() + " s.";
        levelText.text = level.ToString();
    }
    public void loadMainScreen() {
        SceneManager.LoadScene("MainScreen");
    }

    private void adjustTextWidth() {
        /**
         * Adjusts the text width to be 1/2th of the canvas widht. 
         * This prevents the text to overlap with the labels
         */
        float totalScreenWidth = GameObject.Find("Canvas").GetComponent<RectTransform>().rect.width;
        float textLeftOffset = totalScreenWidth * 0.66f;

        RectTransform scoreRt = scoreText.gameObject.GetComponent<RectTransform>();
        RectTransform timeRt = timeText.gameObject.GetComponent<RectTransform>();
        RectTransform levelRt = levelText.gameObject.GetComponent<RectTransform>();

        scoreRt.offsetMin = new Vector2(textLeftOffset, scoreRt.offsetMin.y);
        timeRt.offsetMin = new Vector2(textLeftOffset, timeRt.offsetMin.y);
        levelRt.offsetMin = new Vector2(textLeftOffset, levelRt.offsetMin.y);
    }

}
