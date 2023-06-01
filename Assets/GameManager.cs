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
    public LevelUpTextBehaviour levelUpText;
    public GameOverTextBehaviour gameOverText;

    [Header("Other References")]
    public SoundManager soundManager;
    public MusicManager musicManager;
    public MovementController movementController;

    [Header("Game Parameters")]
    public float playTime;
    public int score;
    public int level;
    public int levelUpTime = 10;   // The Time it takes to level up

    [Header("Spawner Properties")]
    public float spawnerIntervalMultiplier;
    public float obstacleSpeedMultiplier;

    private float levelUpTimer;

    private bool gameActive;

    private GameObject playerInstance;


    void Start() {
        setUpNewGame();
    }

    // Update is called once per frame
    void Update() { if (gameActive == false) return;
        checkLevel();
        updateGameUI();
        playTime += Time.deltaTime;
        score += 1;
    }

    private void checkLevel() {
        levelUpTimer += Time.deltaTime;
        if (levelUpTimer >= levelUpTime) {
            levelUp();
            updateSpawnerProperties();
        }

        if (playerInstance == null) {
            //If the player object doesn't exist, the player is dead
            setUpGameOver();
            disableMovementController();
        }
    }

    private void updateSpawnerProperties() {
        /**
        * Updates the spawner properties with the specified multipliers
        */
        spawner.spawnInterval *= spawnerIntervalMultiplier;
        spawner.spawnObjectMoveDownSpeedMultiplier *= obstacleSpeedMultiplier;
    }

    private void updateGameUI() {
        gameUI.setUIProperties(score, (int)playTime);
    }


    private void levelUp() {
        levelUpTimer = 0f;
        level++;
        levelUpText.playLevelUpAnimation(level);
        soundManager.playLevelUpSound();
    }

    private void spawnPlayer() {   
        playerInstance = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        activateMovementController(playerInstance);
    }

    private void initGameValues() {
        gameActive = true;
        Time.timeScale = 1f;
        playTime = 0f;
        level = 1;
        score = 0;
        levelUpTimer = 0f;
    }

    private void initGameOverValues() {
        gameActive = false;
        Time.timeScale = 0f;
    }

    public void setUpNewGame() {
        initGameValues();
        spawner.resetSpawner();
        spawnPlayer();
        initGameUI();
        musicManager.playLevel01Music();
    }

    private void setUpGameOver() {
        initGameOverValues();
        initGameOverUI();
        soundManager.playDeadSound();
    }

    private void activateMovementController(GameObject objectToMove) {
        movementController.objectToMove = playerInstance;
        movementController.calculateXAxisMoveBorder();
        movementController.enabled = true;
    }

    private void disableMovementController() {
        movementController.enabled = false;
    }

    private void initGameUI() {
        gameOverUI.gameObject.SetActive(false);

        gameUI.resetUI();
        gameUI.gameObject.SetActive(true);
    }

    private void initGameOverUI() {
        gameUI.gameObject.SetActive(false);

        gameOverUI.setGameStats(score, (int)playTime, level);
        gameOverUI.gameObject.SetActive(true);

        gameOverText.createInfoText(level);
        gameOverText.createMotivationText(level);
    }
}
