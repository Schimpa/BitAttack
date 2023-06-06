using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Collects stats about the current game
 * Saves stats to global stats
 * Checks achievement goals
 */
public class GameStatsManager : MonoBehaviour {

    public float currentPlayTime;
    public int currentScore;
    public int currentLevel;

    void Start() {
        resetCurrentGameStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void addCurrentStatsToGlobalStats() {

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
    }
}
