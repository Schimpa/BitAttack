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
    public ObstacleSpawner obstacleSpawner;
    

    [Header("UI References")]
    public GameOverUIManager gameOverUI;
    public GameObject pauseUI;

    [Header("Other Managers")]
    public SoundManager soundManager;
    public MusicManager musicManager;
    public GameStatsManager gameStatsManager;

    [Header("Joysticks")]
    public FixedJoystick joystickRight;
    public FixedJoystick joystickLeft;

    protected MovementController movementController;
    protected GameObject playerPrefab; // The player that will be instantiated by the game manager

    [Header("Game Parameters")]
    public float scoreAddTime = 1f;   // The time it takes to add score
    public int scoreAddTimeAmount = 100;

    public GameObject playerSpawnPosition;

    protected float scoreTimer;

    protected bool gameActive;

    protected GameObject playerInstance;

    private bool playerSpawned;


    protected virtual void Start() {
        playerSpawned = false;
        setUpNewGame();

    }

    // Update is called once per frame
    protected virtual void Update() { if (gameActive == false) return;
        if (playerSpawned == false) {
            spawnPlayer();
            playerSpawned = true;
        }
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
        checkIfPlayerIsDead();
    }

    protected void checkIfPlayerIsDead() {
        //If the player object doesn't exist, the player is dead
        if (playerInstance == null) {       
            setUpGameOverFailed();
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
        PlayerConfigurationManager configManager =
            GameObject.Find("PlayerConfigurationManager").GetComponent<PlayerConfigurationManager>();

        playerPrefab = configManager.getSelectedShip();

        playerInstance = Instantiate(playerPrefab, playerSpawnPosition.transform.position, Quaternion.identity);
        playerInstance.name = "Player";
        setUpMovementController();
    }

    protected virtual void setUpNewGame() {
        initGameValues();
        obstacleSpawner.resetSpawner();
        initGameUI();
        musicManager.playMusic();
    }

    private void setUpGameOver() {
        configureGameOverValues();
        initGameOverUI();
    }

    protected void setUpGameOverFailed() {
        setUpGameOver();
        configureGameOverFailedSound();
    }

    protected void setUpGameOverWin() {
        setUpGameOver();
        configureGameOverWinSound();
    }

    protected void setUpMovementController() {
        movementController = playerInstance.GetComponent<MovementController>();
        movementController.objectToMove = playerInstance;
        movementController.calculateXAxisMoveBorderBySpawner();
        movementController.calculateYAxisMoveBorderByScreenHeight();
    }
    protected virtual void initGameValues() {
        gameActive = true;
        Time.timeScale = 1f;
        gameStatsManager.resetCurrentGameStats();
        scoreTimer = 0f;
    }

    protected void configureGameOverValues() {
        gameActive = false;
        playerSpawned = false;
        Time.timeScale = 0f;
    }

    protected void configureGameOverFailedSound() {
        musicManager.setPlayVolume(0.25f);
        soundManager.playDeadSound();
    }

    protected void configureGameOverWinSound() {
        musicManager.setPlayVolume(0.25f);
        soundManager.playWinSound();
    }

    protected void disableMovementController() {
        //movementController.enabled = false;
    }

    protected virtual void initGameUI() {
        gameOverUI.gameObject.SetActive(false);
    }

    protected virtual void initGameOverUI() {
        int score = gameStatsManager.currentScore;
        int playTime = (int)gameStatsManager.currentPlayTime;
        int level = gameStatsManager.currentLevel;
        int bits = gameStatsManager.currentBitsCollected;

        gameStatsManager.addCurrentGameStatsToGlobalStats();

        gameOverUI.setGameStats(score, (int)playTime, level, bits);
        gameOverUI.gameObject.SetActive(true);

        gameOverUI.createGameOverText(level);
    }
}
