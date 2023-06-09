using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Collects stats about the current game
 * Saves stats to global stats
 * Checks achievement goals
 */
public class GameStatsManager : MonoBehaviour {

    public TotalStageStatsFileManager totalStats;

    public float currentPlayTime;
    public int currentScore;
    public int currentLevel;
    public int currentObstaclesAvoided;
    public int currentCoinsCollected;

    void Start() {
        resetCurrentGameStats();
    }

    public void addCurrentStatsToGlobalStats() {
        totalStats.loadStats();

        StageStats stageStatsRef = totalStats.getStageStats();

        stageStatsRef.totalTimeInSec += currentPlayTime;
        stageStatsRef.totalScore += currentScore;
        stageStatsRef.totalObstaclesAvoided += currentObstaclesAvoided;
        stageStatsRef.totalCoinsCollected += currentCoinsCollected;

        if (stageStatsRef.topLevelReached < currentLevel) {
            stageStatsRef.topLevelReached = currentLevel;
        }

        if (stageStatsRef.topScoreReached < currentScore) {
            stageStatsRef.topScoreReached = currentScore;
        }

        totalStats.saveStats();
    }

    private void checkAchievementRequirements() {

    }

    public void addPlayTime(float value) {
        this.currentPlayTime += value;
    }

    public void addScore(int value) {
        this.currentScore += value;
    }

    public void levelUp() {
        this.currentLevel += 1;
    }

    public void resetCurrentGameStats() {
        currentPlayTime = 0f;
        currentScore = 0;
        currentLevel = 1;
        currentObstaclesAvoided = 0;
        currentCoinsCollected = 0;
    }
}
