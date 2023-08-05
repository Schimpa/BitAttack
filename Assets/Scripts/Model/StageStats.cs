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

    public int level08ReachedAmount;

    public bool achievement01Reached;
    public bool achievement02Reached;
    public bool achievement03Reached;
    public bool achievement04Reached;
    public bool achievement05Reached;
    public bool achievement06Reached;

    public StageStats() {
        this.totalScore = 0;
        this.totalTimeInSec = 0f;
        this.totalObstaclesAvoided = 0;
        this.totalBitsCollected = 0;

        this.topLevelReached = 0;
        this.topScoreReached = 0;
        this.topBitsCollected = 0;
        this.topTimeReachedInSec = 0f;

        this.level08ReachedAmount = 0;

        this.achievement01Reached = false;
        this.achievement02Reached = false;
        this.achievement03Reached = false;
        this.achievement04Reached = false;
        this.achievement05Reached = false;
        this.achievement06Reached = false;
    }


}
