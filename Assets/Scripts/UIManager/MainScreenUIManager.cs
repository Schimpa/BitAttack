using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenUIManager : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject levelOverviewUI;
    public GameObject gamePreparationUI;
    public GameObject setupUI;
    public GameObject shopUI;

    private GamePreparationUIManager gamePreparationUIManager;

    void OnEnable() {
        Time.timeScale = 1;
        gamePreparationUIManager = gamePreparationUI.GetComponent<GamePreparationUIManager>();
        switchToMainMenuUI();
    }

    public void switchToMainMenuUI() { 
        gamePreparationUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        setupUI.SetActive(false);
        shopUI.SetActive(false);

        mainMenuUI.SetActive(true);
    }

    public void switchToLevelOverviewUI() {
        mainMenuUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        setupUI.SetActive(false);
        shopUI.SetActive(false);

        levelOverviewUI.SetActive(true);
    }

    public void switchToGamePreparationUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        setupUI.SetActive(false);
        shopUI.SetActive(false);

        gamePreparationUI.SetActive(true);
    }

    public void switchToSetupUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        shopUI.SetActive(false);

        setupUI.SetActive(true);
    }

    public void switchToShopUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        setupUI.SetActive(false);

        shopUI.SetActive(true);
    }

    public GamePreparationUIManager getGamePreparationUIManager() {
        return this.gamePreparationUIManager;
    }
}
