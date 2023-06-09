using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageStats {

    public int totalScore;
    public float totalTimeInSec;
    public int totalObstaclesAvoided;
    public int totalCoinsCollected;

    public int topLevelReached;
    public int topScoreReached;

    public StageStats() {
        this.totalScore = 0;
        this.totalTimeInSec = 0f;
        this.totalObstaclesAvoided = 0;
        this.totalCoinsCollected = 0;
        this.topLevelReached = 0;
        this.topScoreReached = 0;
    }


}
