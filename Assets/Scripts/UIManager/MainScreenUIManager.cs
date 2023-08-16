using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenUIManager : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject levelOverviewUI;
    public GameObject gamePreparationUI;
    public GameObject introStagePreparationUI;
    public GameObject setupUI;
    public GameObject shopUI;
    public GameObject infoUI;

    private GamePreparationUIManager gamePreparationUIManager;

    void OnEnable() {
        Time.timeScale = 1;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        gamePreparationUIManager = gamePreparationUI.GetComponent<GamePreparationUIManager>();
        switchToMainMenuUI();
    }

    public void switchToMainMenuUI() { 
        gamePreparationUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        setupUI.SetActive(false);
        shopUI.SetActive(false);
        introStagePreparationUI.SetActive(false);
        infoUI.SetActive(false);

        mainMenuUI.SetActive(true);
    }

    public void switchToLevelOverviewUI() {
        mainMenuUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        setupUI.SetActive(false);
        shopUI.SetActive(false);
        introStagePreparationUI.SetActive(false);
        infoUI.SetActive(false);

        levelOverviewUI.SetActive(true);
    }

    public void switchToGamePreparationUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        setupUI.SetActive(false);
        shopUI.SetActive(false);
        introStagePreparationUI.SetActive(false);
        infoUI.SetActive(false);

        gamePreparationUI.SetActive(true);
    }

    public void switchToSetupUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        shopUI.SetActive(false);
        introStagePreparationUI.SetActive(false);
        infoUI.SetActive(false);

        setupUI.SetActive(true);
    }

    public void switchToShopUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        setupUI.SetActive(false);
        introStagePreparationUI.SetActive(false);
        infoUI.SetActive(false);

        shopUI.SetActive(true);
    }
     
    public void switchToIntroStagePreparationUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        setupUI.SetActive(false);
        shopUI.SetActive(false);
        infoUI.SetActive(false);

        introStagePreparationUI.SetActive(true);
      
    }

    public void switchToInfoUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        setupUI.SetActive(false);
        shopUI.SetActive(false);
        introStagePreparationUI.SetActive(false);

        infoUI.SetActive(true);
    }

    public GamePreparationUIManager getGamePreparationUIManager() {
        return this.gamePreparationUIManager;
    }

    public void loadIntroStage() {
        SceneManager.LoadScene("IntroStoryScene");
    }

    public void exitGame() {
        Application.Quit();
    }
}
