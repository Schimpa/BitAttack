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

    public TMPro.TMP_Text achievement01Text;
    public TMPro.TMP_Text achievement02Text;
    public TMPro.TMP_Text achievement03Text;

    public TMPro.TMP_Text achievementTitleText;

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

        StageStats stats = totalStats.getStageStats();

        setUITextValues(stats);
        checkAchievementValidation(stats);
    }

    public void setUITextValues(StageStats stats) {
        double totalTime = System.Math.Round(stats.totalTimeInSec, 2);
        double topTime = System.Math.Round(stats.topTimeReachedInSec, 2);

        topLevelText.text = stats.topLevelReached.ToString();
        topScoreText.text = stats.topScoreReached.ToString();
        topTimeText.text = topTime.ToString() + "s";

        totalTimeText.text = totalTime.ToString() + "s";
        totalScoreText.text = stats.totalScore.ToString();
        coinsCollectedText.text = stats.totalCoinsCollected.ToString();
        obstaclesAvoidedText.text = stats.totalObstaclesAvoided.ToString();
    }

    public void checkAchievementValidation(StageStats stats) {
        int achievementsReached = 3;

        if (stats.achievement01Reached == false) {
            achievement01Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        }
        if (stats.achievement02Reached == false) {
            achievement02Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        }
        if (stats.achievement03Reached == false) {
            achievement03Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        }

        achievementTitleText.text = "Achievements: " + achievementsReached.ToString() + "/3";
    }

}
