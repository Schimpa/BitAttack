using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


/**
 * Wofür soll dieses Skript zuständing sein?
 * - Den Spawner kontrollieren, Spawnrate und Geschwindigkeit einstellen
 * - Spielzeit, Score und Level verwalten
 * - Spiel starten / beenden
 * 
 */
public class GameManager : MonoBehaviour {

    [Header("Game Object References")]
    public Spawner spawner;
    public GameObject playerPrefab;

    [Header("UI References")]
    public GameUIManager gameUI;
    public GameOverUIManager gameOverUI;

    [Header("Other Managers")]
    public SoundManager soundManager;
    public MusicManager musicManager;
    public GameStatsManager gameStatsManager;

    [Header("Other Controllers")]
    public MovementController movementController;

    [Header("Game Parameters")]
    public int levelUpTime = 10;   // The time it takes to level up
    public float scoreAddTime = 1f;   // The time it takes to add score
    public int scoreAddTimeAmount = 100;

    private float levelUpTimer;
    private float scoreTimer;

    private bool gameActive;

    private GameObject playerInstance;


    void Start() {
        setUpNewGame();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update() { if (gameActive == false) return;
        checkLevel();
        checkScore();
        updateGameUI();
        gameStatsManager.addPlayTime(Time.deltaTime);
    }

    private void checkLevel() {
        levelUpTimer += Time.deltaTime;
        if (levelUpTimer >= levelUpTime) {
            levelUp();
            
        }

        if (playerInstance == null) {
            //If the player object doesn't exist, the player is dead
            setUpGameOver();
            disableMovementController();
        }
    }

    private void checkScore() {
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= scoreAddTime) {
            gameStatsManager.addScore(scoreAddTimeAmount);
            scoreTimer = 0f;
        }
    }

    private void updateGameUI() {
        int score = gameStatsManager.currentScore;
        float playTime = gameStatsManager.currentPlayTime;

        gameUI.setUIProperties(score);
    }


    private void levelUp() {
        levelUpTimer = 0f;
        gameStatsManager.levelUp();
        gameUI.playLevelUpAnimation(gameStatsManager.currentLevel);
        soundManager.playLevelUpSound();
        spawner.levelUp();
    }

    private void spawnPlayer() {   
        playerInstance = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        playerInstance.name = "Player";
        activateMovementController(playerInstance);

        PlayerConfigurationManager configManager =
            GameObject.Find("PlayerConfigurationManager").GetComponent<PlayerConfigurationManager>();

        playerInstance.GetComponent<MeshFilter>().mesh = configManager.getSelectedShip();
    }

    public void setUpNewGame() {
        initGameValues();
        spawner.resetSpawner();
        spawnPlayer();
        initGameUI();
        musicManager.playMusic();
    }

    private void setUpGameOver() {
        configureGameOverValues();
        initGameOverUI();
        gameStatsManager.addCurrentStatsToGlobalStats();
        configureGameOverSound();
    }

    private void activateMovementController(GameObject objectToMove) {
        movementController.objectToMove = playerInstance;
        movementController.calculateXAxisMoveBorder();
        movementController.enabled = true;
    }
    private void initGameValues() {
        gameActive = true;
        Time.timeScale = 1f;
        gameStatsManager.resetCurrentGameStats();
        levelUpTimer = 0f;
        scoreTimer = 0f;
    }

    private void configureGameOverValues() {
        gameActive = false;
        Time.timeScale = 0f;
    }

    private void configureGameOverSound() {
        musicManager.setPlayVolume(0.25f);
        soundManager.playDeadSound();
    }

    private void disableMovementController() {
        movementController.enabled = false;
    }

    private void initGameUI() {
        gameOverUI.gameObject.SetActive(false);

        gameUI.resetUI();
        gameUI.gameObject.SetActive(true);
        gameUI.playLevelUpEmptyAnimation();

        movementController.setJoyStickActive(true);
    }

    private void initGameOverUI() {
        int score = gameStatsManager.currentScore;
        int playTime = (int)gameStatsManager.currentPlayTime;
        int level = gameStatsManager.currentLevel;
        int coins = gameStatsManager.currentCoinsCollected;

        gameUI.gameObject.SetActive(false);

        gameOverUI.setGameStats(score, (int)playTime, level, coins);
        gameOverUI.gameObject.SetActive(true);

        gameOverUI.createGameOverText(level);

        movementController.setJoyStickActive(false);
    }
}
