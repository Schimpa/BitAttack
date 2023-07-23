using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


/**
 Base class for Game Managers. Every Game Manager shall inherit from
this base class and then implement their own specific game implementation
 */
public abstract class GameManagerBase : MonoBehaviour {

    [Header("Game Object References")]
    public Spawner spawner;
    public GameObject playerPrefab; // The player that will be instantiated by the game manager

    [Header("UI References")]
    public GameOverUIManager gameOverUI;
    public GameObject pauseUI;

    [Header("Other Managers")]
    public SoundManager soundManager;
    public MusicManager musicManager;
    public GameStatsManager gameStatsManager;

    [Header("Other Controllers")]
    public MovementController movementController;

    [Header("Game Parameters")]
    public float scoreAddTime = 1f;   // The time it takes to add score
    public int scoreAddTimeAmount = 100;

    protected float scoreTimer;

    protected bool gameActive;

    protected GameObject playerInstance;


    protected virtual void Start() {
        setUpNewGame();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    protected virtual void Update() { if (gameActive == false) return;
        checkGameConditions();
        checkScore();
        gameStatsManager.addPlayTime(Time.deltaTime);
        checkPauseGameControl();
    }

    private void checkPauseGameControl() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseGame();
        }
    }

    public void pauseGame() {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void continueGame() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    protected virtual void checkGameConditions() {
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

    protected void spawnPlayer() {   
        playerInstance = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        playerInstance.name = "Player";
        activateMovementController(playerInstance);

        PlayerConfigurationManager configManager =
            GameObject.Find("PlayerConfigurationManager").GetComponent<PlayerConfigurationManager>();

        playerInstance.GetComponent<MeshFilter>().mesh = configManager.getSelectedShip();
    }

    protected virtual void setUpNewGame() {
        initGameValues();
        spawner.resetSpawner();
        spawnPlayer();
        initGameUI();
        musicManager.playMusic();
    }

    protected void setUpGameOver() {
        configureGameOverValues();
        initGameOverUI();
        gameStatsManager.addCurrentStatsToGlobalStats();
        configureGameOverSound();
    }

    protected void activateMovementController(GameObject objectToMove) {
        movementController.objectToMove = playerInstance;
        movementController.calculateXAxisMoveBorder();
        movementController.enabled = true;
    }
    protected virtual void initGameValues() {
        gameActive = true;
        Time.timeScale = 1f;
        gameStatsManager.resetCurrentGameStats();
        scoreTimer = 0f;
    }

    protected void configureGameOverValues() {
        gameActive = false;
        Time.timeScale = 0f;
    }

    protected void configureGameOverSound() {
        musicManager.setPlayVolume(0.25f);
        soundManager.playDeadSound();
    }

    protected void disableMovementController() {
        movementController.enabled = false;
    }

    protected virtual void initGameUI() {
        gameOverUI.gameObject.SetActive(false);
        movementController.setJoyStickActive(true);
    }

    protected virtual void initGameOverUI() {
        int score = gameStatsManager.currentScore;
        int playTime = (int)gameStatsManager.currentPlayTime;
        int level = gameStatsManager.currentLevel;
        int bits = gameStatsManager.currentBitsCollected;

        gameOverUI.setGameStats(score, (int)playTime, level, bits);
        gameOverUI.gameObject.SetActive(true);

        gameOverUI.createGameOverText(level);

        movementController.setJoyStickActive(false);
    }
}
