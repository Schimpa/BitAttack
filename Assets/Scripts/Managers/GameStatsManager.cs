using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Collects stats about the current game
 * Saves stats to global stats
 * Checks achievement goals
 */
public class GameStatsManager : MonoBehaviour {

    public StageStatsFileManager stageStats;
    public GlobalStatsFileManager globalStats;

    public float currentPlayTime;
    public int currentScore;
    public int currentLevel;
    public int currentObstaclesAvoided;
    public int currentBitsCollected;

    void Start() {
        resetCurrentGameStats();
    }

    public void addCurrentGameStatsToGlobalStats() {
        StageStats stageStatsRef = stageStats.getStageStats();
        GlobalStats globalStatsRef = globalStats.getGlobalStats();

        updateStageStats(stageStatsRef);
        updateGlobalStats(globalStatsRef);

        stageStats.saveStats();
        globalStats.saveStats();
    }

    private void updateStageStats(StageStats stageStatsRef) {
        stageStatsRef.totalTimeInSec += currentPlayTime;
        stageStatsRef.totalScore += currentScore;
        stageStatsRef.totalObstaclesAvoided += currentObstaclesAvoided;
        stageStatsRef.totalBitsCollected += currentBitsCollected;

        if (stageStatsRef.topLevelReached < currentLevel) {
            stageStatsRef.topLevelReached = currentLevel;
        }

        if (stageStatsRef.topScoreReached < currentScore) {
            stageStatsRef.topScoreReached = currentScore;
        }

        if (stageStatsRef.topBitsCollected < currentBitsCollected) {
            stageStatsRef.topBitsCollected = currentBitsCollected;
        }

        if (stageStatsRef.topTimeReachedInSec < currentPlayTime) {
            stageStatsRef.topTimeReachedInSec = currentPlayTime;
        }

        if (currentLevel >= 8) {
            stageStatsRef.level08ReachedAmount++;
        }
    }
    private void updateGlobalStats(GlobalStats globalStatsRef) {
        globalStatsRef.bits += currentBitsCollected;
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

