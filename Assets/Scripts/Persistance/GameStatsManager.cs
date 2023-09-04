using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Collects stats about the current game
 * Saves stats to global stats
 * Checks achievement goals
 */
public class GameStatsManager : MonoBehaviour {

    public StageStatsFileManager stageStatsFileManager;
    public GlobalStatsFileManager globalStatsFileManager;

    public float currentPlayTime;
    public int currentScore;
    public int currentLevel;
    public int currentObstaclesAvoided;
    public int currentBitsCollected;

    void Start() {
        resetCurrentGameStats();
    }

    public void addCurrentGameStatsToGlobalStats() {
        StageStats stageStats = stageStatsFileManager.getStageStats();
        GlobalStats globalStats = globalStatsFileManager.getGlobalStats();

        updateStageStatsWithCurrentStats(stageStats);
        updateGlobalStatsWithCurrentStats(globalStats);

        stageStatsFileManager.checkIfNewAchievementUnlocked();

        stageStatsFileManager.saveStats();
        globalStatsFileManager.saveStats();
    }

    private void updateStageStatsWithCurrentStats(StageStats stageStats) {
        stageStats.totalTimeInSec += currentPlayTime;
        stageStats.totalScore += currentScore;
        stageStats.totalObstaclesAvoided += currentObstaclesAvoided;
        stageStats.totalBitsCollected += currentBitsCollected;

        if (stageStats.topLevelReached < currentLevel) {
            stageStats.topLevelReached = currentLevel;
        }

        if (stageStats.topScoreReached < currentScore) {
            stageStats.topScoreReached = currentScore;
        }

        if (stageStats.topBitsCollected < currentBitsCollected) {
            stageStats.topBitsCollected = currentBitsCollected;
        }

        if (stageStats.topTimeReachedInSec < currentPlayTime) {
            stageStats.topTimeReachedInSec = currentPlayTime;
        }

    }
    private void updateGlobalStatsWithCurrentStats(GlobalStats globalStats) {
        globalStats.bits += currentBitsCollected;
    }

    public void addPlayTime(float value) {
        this.currentPlayTime += value;
    }

    public void addScore(int value) {
        this.currentScore += value;
    }

    public void addBits(int value) {
        this.currentBitsCollected += value;
    }

    public void levelUp() {
        this.currentLevel += 1;
    }

    public void resetCurrentGameStats() {
        currentPlayTime = 0f;
        currentScore = 0;
        currentLevel = 1;
        currentObstaclesAvoided = 0;
        currentBitsCollected = 0;
    }

}

