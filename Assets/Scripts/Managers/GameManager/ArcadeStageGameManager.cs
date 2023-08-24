using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ArcadeStageGameManager : GameManagerBase {

    [Header("UI References")]
    public StageGameUIManager gameUI;


    private int levelUpTime;

    private float levelUpTimer;

    protected override void Start() {
        base.Start();
        levelUpTime = PlayerPrefs.GetInt(ArcadeKeys.LEVEL_DURATION.ToString());
    }

    // Update is called once per frame
    protected override void Update() {if (gameActive == false) return;
        base.Update();
        updateGameUI();
    }

    protected override void checkGameConditions() {
        base.checkGameConditions();

        levelUpTimer += Time.deltaTime;

        if (levelUpTimer >= levelUpTime) {
            levelUp();         
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

    }

    public override void setUpNewGame() {
        base.setUpNewGame();
        obstacleSpawner.gameObject.SetActive(true);
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
    }
}
