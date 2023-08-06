using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePreparationUIManager : MonoBehaviour {

    public StageStatsFileManager stageStatsFileManager;

    public TMPro.TMP_Text topLevelText;
    public TMPro.TMP_Text topScoreText;
    public TMPro.TMP_Text topTimeText;

    public TMPro.TMP_Text totalTimeText;
    public TMPro.TMP_Text totalScoreText;
    public TMPro.TMP_Text bitsCollectedText;
    public TMPro.TMP_Text obstaclesAvoidedText;

    public TMPro.TMP_Text achievement01Text;
    public TMPro.TMP_Text achievement02Text;
    public TMPro.TMP_Text achievement03Text;
    public TMPro.TMP_Text achievement04Text;
    public TMPro.TMP_Text achievement05Text;
    public TMPro.TMP_Text achievement06Text;

    public TMPro.TMP_Text achievementTitleText;

    private string levelToLoad = "";

    private void OnEnable() {
        setUp();
    }
    private void Start() {
        setUp();
    }

    public void onLoadLevelButton() {
        if (levelToLoad == "") {
            Debug.LogError("Level to load is not specified!");
        } else {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    private void setUp() {
        stageStatsFileManager.updateStatsFileName(levelToLoad);
        stageStatsFileManager.loadStats();

        StageStats stats = stageStatsFileManager.getStageStats();

        setUITextValues(stats);
        checkAchievementValidation(stats);
    }

    public void setFileNameToLoad(string levelToLoad) {
        this.levelToLoad = levelToLoad;
    }

    public void setUITextValues(StageStats stats) {
        double totalTime = System.Math.Round(stats.totalTimeInSec, 2);
        double topTime = System.Math.Round(stats.topTimeReachedInSec, 2);

        topLevelText.text = stats.topLevelReached.ToString();
        topScoreText.text = stats.topScoreReached.ToString();
        topTimeText.text = topTime.ToString() + " sec.";

        totalTimeText.text = totalTime.ToString() + " sec.";
        totalScoreText.text = stats.totalScore.ToString();
        bitsCollectedText.text = stats.totalBitsCollected.ToString();
        obstaclesAvoidedText.text = stats.totalObstaclesAvoided.ToString();
    }

    public void checkAchievementValidation(StageStats stats) {
        int achievementsReached = 6;
        stageStatsFileManager.validateStage01Achievements();

        if (stats.achievement01Reached == false) {
            achievement01Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        } else {
            achievement01Text.color = new Color(1, 1, 1, 1f);
        }
        if (stats.achievement02Reached == false) {
            achievement02Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        } else {
            achievement02Text.color = new Color(1, 1, 1, 1f);
        }
        if (stats.achievement03Reached == false) {
            achievement03Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        } else {
            achievement03Text.color = new Color(1, 1, 1, 1f);
        }
        if (stats.achievement04Reached == false) {
            achievement04Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        } else {
            achievement04Text.color = new Color(1, 1, 1, 1f);
        }
        if (stats.achievement05Reached == false) {
            achievement05Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        } else {
            achievement05Text.color = new Color(1, 1, 1, 1f);
        }
        if (stats.achievement06Reached == false) {
            achievement06Text.color = new Color(1, 1, 1, .3f);
            achievementsReached--;
        } else {
            achievement06Text.color = new Color(1, 1, 1, 1f);
        }

        achievementTitleText.text = "Achievements: " + achievementsReached.ToString() + "/6";
    }

}
