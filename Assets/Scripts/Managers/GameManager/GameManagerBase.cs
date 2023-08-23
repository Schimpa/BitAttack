using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

/**
 Base class for Game Managers. Every Game Manager shall inherit from
this base class and then implement their own specific game implementation
 */
public abstract class GameManagerBase : MonoBehaviour {

    [Header("What shall happen when the game starts?")]
    public UnityEvent startEvents;

    [Header("What shall happen when the game was lost?")]
    public UnityEvent gameOverEvents;

    [Header("What shall happen when the game was won?")]
    public UnityEvent gameWinEvents;

    [Header("Spawners")]
    public ObstacleSpawner obstacleSpawner;
    public BasicSpawner enemyShipSpawner;

    [Header("Activate or deactivate components on game start")]
    public bool obstacleSpawnerActiveOnStart;
    public bool movementControllerActiveOnStart;
    public bool weaponControllerActiveOnStart;

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

    [Header("Game Parameters")]
    public float scoreAddTime = 1f;   // The time it takes to add score
    public int scoreAddTimeAmount = 100;

    public GameObject playerSpawnPosition;

    protected MovementController movementController;
    protected PlayerWeaponController playerWeaponController;
    protected GameObject playerPrefab; // The player that will be instantiated by the game manager

    protected float scoreTimer;

    protected bool gameActive;

    protected GameObject playerInstance;

    private bool playerSpawned;


    protected virtual void Start() {
        playerSpawned = false;
        setUpNewGame();
        obstacleSpawner.gameObject.SetActive(obstacleSpawnerActiveOnStart);
        startEvents.Invoke();
    }

    // Update is called once per frame
    protected virtual void Update() { if (gameActive == false) return;
        spawnPlayer();
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
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void continueGame() {
        pauseUI.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    protected virtual void checkGameConditions() {
        checkIfPlayerIsDead();
    }

    protected void checkIfPlayerIsDead() {
        //If the player object doesn't exist, the player is dead
        if (playerInstance == null) {       
            setUpGameOverFailed();
        }
    }

    private void checkScore() {
        scoreTimer += Time.deltaTime;
        if (scoreTimer >= scoreAddTime) {
            gameStatsManager.addScore(scoreAddTimeAmount);
            scoreTimer = 0f;
        }
    }

    public void spawnPlayer() { if (playerSpawned == true) return;
        PlayerConfigurationManager configManager =
            GameObject.Find("PlayerConfigurationManager").GetComponent<PlayerConfigurationManager>();

        playerPrefab = configManager.getSelectedShip();

        playerInstance = Instantiate(playerPrefab, playerSpawnPosition.transform.position, Quaternion.identity);
        playerInstance.name = "Player";

        playerWeaponController = playerInstance.GetComponent<PlayerWeaponController>();
        playerWeaponController.enabled = weaponControllerActiveOnStart;
        setUpMovementController();

        playerSpawned = true;
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
        gameOverEvents.Invoke();
        Cursor.visible = true;
    }

    protected virtual void setUpGameOverWin() {
        setUpGameOver();
        configureGameOverWinSound();
        gameWinEvents.Invoke();
        movementController.enabled = false;
        Cursor.visible = true;
    }

    protected void setUpMovementController() {
        movementController = playerInstance.GetComponent<MovementController>();
        movementController.objectToMove = playerInstance;
        movementController.spawner = obstacleSpawner;
        movementController.calculateXAxisMoveBorderBySpawner();
        movementController.calculateYAxisMoveBorderByScreenHeight();

        movementController.enabled = movementControllerActiveOnStart;
    }
    protected virtual void initGameValues() {
        gameActive = true;
        gameStatsManager.resetCurrentGameStats();
        scoreTimer = 0f;
    }

    protected void configureGameOverValues() {
        gameActive = false;
        playerSpawned = false;
        Cursor.visible = true;
    }

    protected void configureGameOverFailedSound() {
        musicManager.setPlayVolume(0.25f);
        soundManager.playDeadSound();
    }

    protected void configureGameOverWinSound() {
        musicManager.setPlayVolume(0.25f);
        soundManager.playWinSound();
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

    public void enablePlayerMovementController() { if (movementController == null) return;
        this.movementController.enabled = true;
        movementControllerActiveOnStart = true;
    }

    public void enablePlayerWeaponController() {if (playerWeaponController == null) return;
        this.playerWeaponController.enabled = true;
        weaponControllerActiveOnStart = true;
    }

    public void setGameActive(bool value) {
        this.gameActive = value;
    }
}
