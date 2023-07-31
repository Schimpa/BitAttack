using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour {

    public TMPro.TMP_Text titleText;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text timeText;
    public TMPro.TMP_Text levelText;
    public TMPro.TMP_Text bitsText;

    public GameOverTextBehaviour gameOverText;

    public void OnEnable() {
        adjustTextWidth();
    }

    public void setGameStats(int score, int time, int level, int bits) {
        scoreText.text = score.ToString();
        timeText.text = time.ToString() + " s.";
        levelText.text = level.ToString();
        bitsText.text = bits.ToString();
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
        RectTransform bitsRt = bitsText.gameObject.GetComponent<RectTransform>();

        scoreRt.offsetMin = new Vector2(textLeftOffset, scoreRt.offsetMin.y);
        timeRt.offsetMin  = new Vector2(textLeftOffset, timeRt.offsetMin.y);
        levelRt.offsetMin = new Vector2(textLeftOffset, levelRt.offsetMin.y);
        bitsRt.offsetMin = new Vector2(textLeftOffset, bitsRt.offsetMin.y);
    }

    public void createGameOverText(int level) {
        gameOverText.createMotivationTextByLevel(level);
    }

    public void setTitleText(string text) {
        titleText.text = text;
    }

}
