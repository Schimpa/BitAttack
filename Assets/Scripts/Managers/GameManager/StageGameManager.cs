using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class StageGameManager : GameManagerBase {

    [Header("UI References")]
    public StageGameUIManager gameUI;

    [Header("Game Parameters")]
    public int levelUpTime = 10;   // The time it takes to level up

    public BasicSpawner enemyShipSpawner;

    private float levelUpTimer;

    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update() {if (gameActive == false) return;
        base.Update();
        updateGameUI();
    }

    protected override void checkGameConditions() {
        base.checkGameConditions();

        if ( gameStatsManager.currentLevel % 5 == 0) {
            handleEnemyShipLevel();

        } else {
            handleObstacleLevel();        
        }
      
        if (levelUpTimer >= levelUpTime) {
            levelUp();         
        }
    }

    private void handleObstacleLevel() {
        levelUpTimer += Time.deltaTime;
    }

    private void handleEnemyShipLevel() {
        if (enemyShipSpawner.getSpawnedObjectsCount() > 0) {

        } else {
            if (obstacleSpawner.gameObject.activeSelf == false) {
                obstacleSpawner.gameObject.SetActive(true);
            }
            levelUpTimer += Time.deltaTime;
        }
    }

    private void updateGameUI() {
        int score = gameStatsManager.currentScore;
        int bits = gameStatsManager.currentBitsCollected;

        gameUI.updateUIProperties(score, bits);
    }


    private void levelUp() {
        levelUpTimer = 0f;
        gameStatsManager.levelUp();
        gameUI.playLevelUpAnimation(gameStatsManager.currentLevel);
        soundManager.playLevelUpSound();
        obstacleSpawner.levelUp();

        if (gameStatsManager.currentLevel % 5 == 0) {
            activateEnemyShip();
        }
    }

    private void activateEnemyShip() {
        obstacleSpawner.gameObject.SetActive(false);
        enemyShipSpawner.spawnNewObject();
    }

    protected override void setUpNewGame() {
        base.setUpNewGame();
        obstacleSpawner.gameObject.SetActive(true);
        enemyShipSpawner.resetSpawner();
        pauseUI.SetActive(false);
    }

    protected override void initGameValues() {
        base.initGameValues();
        levelUpTimer = 0f;
    }

    protected override void initGameUI() {
        base.initGameUI();
        gameUI.resetUI();
        gameUI.gameObject.SetActive(true);
        gameUI.playLevelUpEmptyAnimation();
    }

    protected override void initGameOverUI() {
        base.initGameOverUI();
        createAchievementTextIfFirstTimeUnlocked();
    }

    private void createAchievementTextIfFirstTimeUnlocked() {
        gameStatsManager.stageStats.validateStage01Achievements();
        if (gameStatsManager.stageStats.isNewAchievementUnlocked()) {
            this.gameOverUI.gameOverText.setCustomInfoText("Achievement unlocked!");
            gameStatsManager.stageStats.setNewAchievementUnlocked(false);
        } else {
            this.gameOverUI.gameOverText.setCustomInfoText("");
        }
    }
}
