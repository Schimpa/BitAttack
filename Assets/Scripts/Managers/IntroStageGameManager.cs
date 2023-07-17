using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


public class IntroStageGameManager : MonoBehaviour {

    [Header("Game Object References")]
    public Spawner spawner;
    public GameObject playerPrefab;
    public GameObject restartButton;    // To disable the restart button when the player won the game

    [Header("UI References")]
    public IntroGameUIManager gameUI;
    public GameOverUIManager gameOverUI;

    [Header("Other Managers")]
    public SoundManager soundManager;
    public MusicManager musicManager;
    public GameStatsManager gameStatsManager;

    [Header("Other Controllers")]
    public MovementController movementController;

    [Header("Game Parameters")]
    public float scoreAddTime = 1f;   // The time it takes to add score
    public int scoreAddTimeAmount = 10;

    [Header("Winning condition")]
    public int bitsToWin;

    [Header("Spawner Properties")]
    public float spawnerIntervalMultiplier;
    public float obstacleSpeedMultiplier;

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
        checkGameConditions();
        checkScore();
        updateGameUI();
        gameStatsManager.addPlayTime(Time.deltaTime);
    }

    private void checkGameConditions() {
        if (playerInstance == null) { // When the player lost the game
            setUpGameOver();
            setUpGameOverFailedText();
            disableMovementController();
        }

        if (gameStatsManager.currentBitsCollected >= bitsToWin) { // When the player won the game
            setUpGameOverWinText();
            setUpGameOver();
            restartButton.SetActive(false);
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
        int currentBitsCollected = gameStatsManager.currentBitsCollected;

        gameUI.updateUIProperties(score, currentBitsCollected);
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

        movementController.setJoyStickActive(true);
    }

    private void initGameOverUI() {
        int score = gameStatsManager.currentScore;
        int playTime = (int)gameStatsManager.currentPlayTime;
        int level = gameStatsManager.currentLevel;
        int bits = gameStatsManager.currentBitsCollected;

        gameUI.gameObject.SetActive(false);

        gameOverUI.setGameStats(score, (int)playTime, level, bits);
        gameOverUI.gameObject.SetActive(true);

        movementController.setJoyStickActive(false);
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
}
