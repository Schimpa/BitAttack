using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class IntroStageGameManager : GameManagerBase {

    [Header("Game Object References")]
    public GameObject restartButton;    // To disable the restart button when the player won the game

    [Header("UI References")]
    public IntroGameUIManager gameUI;

    [Header("Winning condition")]
    public int bitsToWin;

    [Header("What shall happen when the enemy ship spawns?")]
    public UnityEvent enemyShipSpawnEvent;

    private bool enemyShipSpawned;
    private bool enemyShipDestroyed;

    protected override void Start() {
        base.Start();
        enemyShipDestroyed = false;
        enemyShipSpawned = false;
    }

    // Update is called once per frame
    protected override void Update() { if (gameActive == false) return;
        base.Update();
        updateGameUI();

    }
    protected override void checkGameConditions() {
        base.checkGameConditions();
        if (playerInstance == null) { // When the player lost the game
            setUpGameOverFailedText();
            // Game Over Failed Setup is done in the base method
        }

        if (enemyShipSpawned == false && gameStatsManager.currentBitsCollected >= bitsToWin) {
            activateEnemyShip();         
        }

        if (enemyShipSpawned) {
            checkIfEnemyShipDestroyed();
        }

        if (enemyShipDestroyed) {
            setUpGameWin();
        }
    }

    private void setUpGameWin() {
        setUpGameOverWinText();
        setUpGameOverWin();
        restartButton.SetActive(false);
    }

    private void checkIfEnemyShipDestroyed() {
        if (enemyShipSpawner.getSpawnedObjectsCount() > 0) {

        } else {
            if (obstacleSpawner.gameObject.activeSelf == false) {
                obstacleSpawner.gameObject.SetActive(true);
            }
            enemyShipDestroyed = true;
        }
    }

    private void activateEnemyShip() {
        obstacleSpawner.gameObject.SetActive(false);
        enemyShipSpawner.spawnNewObject();
        enemyShipSpawned = true;
        enemyShipSpawnEvent.Invoke();
    }

    private void updateGameUI() {
        int score = gameStatsManager.currentScore;
        int currentBitsCollected = gameStatsManager.currentBitsCollected;

        gameUI.updateUIProperties(score, currentBitsCollected);
    }

    public override void setUpNewGame() {
        base.setUpNewGame();
        pauseUI.SetActive(false);
    }

    protected override void initGameUI() {
        base.initGameUI();

        gameUI.resetUI();
        gameUI.gameObject.SetActive(true);      
    }

    private void setUpGameOverWinText() {
        gameOverUI.gameOverText.setCustomInfoText("Very nice!");
        gameOverUI.gameOverText.setCustomMotivationText("");
        gameOverUI.titleText.text = "Intro stage done!";
    }

    private void setUpGameOverFailedText() {
        gameOverUI.gameOverText.setCustomInfoText("You really failed the intro level...");
        gameOverUI.gameOverText.setCustomMotivationText("");
        gameOverUI.titleText.text = "Intro stage failed!";
    }

    protected override void initGameOverUI() {
        base.initGameOverUI();
        gameUI.gameObject.SetActive(false);
    }

    protected override void setUpGameOverWin() {
        base.setUpGameOverWin();
        unlockLevel01();
    }

    private void unlockLevel01() {
        gameStatsManager.globalStatsFileManager.getGlobalStats().level01Unlocked = true;
        gameStatsManager.globalStatsFileManager.saveStats();
    }

    public void reloadScene() {
        SceneManager.LoadScene("IntroStage");
    }
}
