using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


public class IntroStageGameManager : GameManagerBase {

    [Header("Game Object References")]
    public GameObject restartButton;    // To disable the restart button when the player won the game

    [Header("UI References")]
    public IntroGameUIManager gameUI;

    [Header("Winning condition")]
    public int bitsToWin;

    protected override void Start() {
        base.Start();
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

        if (gameStatsManager.currentBitsCollected >= bitsToWin) { // When the player won the game
            setUpGameOverWinText();
            setUpGameOverWin();
            restartButton.SetActive(false);
        }
    }

    private void updateGameUI() {
        int score = gameStatsManager.currentScore;
        int currentBitsCollected = gameStatsManager.currentBitsCollected;

        gameUI.updateUIProperties(score, currentBitsCollected);
    }

    protected override void setUpNewGame() {
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
}
