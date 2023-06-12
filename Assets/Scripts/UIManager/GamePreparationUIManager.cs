using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePreparationUIManager : MonoBehaviour {

    public TotalStageStatsFileManager totalStats;

    public TMPro.TMP_Text topLevelText;
    public TMPro.TMP_Text topScoreText;
    public TMPro.TMP_Text topTimeText;

    public TMPro.TMP_Text totalTimeText;
    public TMPro.TMP_Text totalScoreText;
    public TMPro.TMP_Text coinsCollectedText;
    public TMPro.TMP_Text obstaclesAvoidedText;

    private string levelToLoad = "";

    public void onLoadLevelButton() {
        if (levelToLoad == "") {
            Debug.LogError("Level to load is not specified!");
        } else {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void configureUI(string levelToLoad) {
        this.levelToLoad = levelToLoad;

        totalStats.updateStatsFileName(levelToLoad);
        totalStats.loadStats();

        setUITextValues();
    }

    public void setUITextValues() {
        StageStats stats = totalStats.getStageStats();

        double totalTime = System.Math.Round(stats.totalTimeInSec, 2);
        double topTime = System.Math.Round(stats.topTimeReachedInSec, 2);

        topLevelText.text = stats.topLevelReached.ToString();
        topScoreText.text = stats.topScoreReached.ToString();
        topTimeText.text = topTime.ToString();

        totalTimeText.text = totalTime.ToString();
        totalScoreText.text = stats.totalScore.ToString();
        coinsCollectedText.text = stats.totalCoinsCollected.ToString();
        obstaclesAvoidedText.text = stats.totalObstaclesAvoided.ToString();

    }
}
