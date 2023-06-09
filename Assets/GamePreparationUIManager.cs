using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreparationUIManager : MonoBehaviour {

    public TotalStageStatsFileManager totalStats;

    public TMPro.TMP_Text topLevelText;
    public TMPro.TMP_Text topScoreText;
    public TMPro.TMP_Text totalTimeText;
    public TMPro.TMP_Text totalScoreText;

    void Start() {
        totalStats.loadStats();

        StageStats stats = totalStats.getStageStats();

        topLevelText.text = stats.topLevelReached.ToString();
        topScoreText.text = stats.topScoreReached.ToString();
        totalTimeText.text = stats.totalTimeInSec.ToString();
        totalScoreText.text = stats.totalScore.ToString();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
