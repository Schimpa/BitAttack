using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageStats {

    public int totalScore;
    public float totalTimeInSec;
    public int totalObstaclesAvoided;
    public int totalBitsCollected;

    public int topLevelReached;
    public int topScoreReached;
    public int topBitsCollected;
    public float topTimeReachedInSec;

    public StageStats() {
        this.totalScore = 0;
        this.totalTimeInSec = 0f;
        this.totalObstaclesAvoided = 0;
        this.totalBitsCollected = 0;

        this.topLevelReached = 0;
        this.topScoreReached = 0;
        this.topBitsCollected = 0;
        this.topTimeReachedInSec = 0f;
    }
}
