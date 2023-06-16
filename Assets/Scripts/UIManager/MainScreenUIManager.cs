using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenUIManager : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject levelOverviewUI;
    public GameObject gamePreparationUI;
    public GameObject setupUI;

    public GamePreparationUIManager gamePreparationUIManager;

    void Start() {
        Time.timeScale = 1;
        gamePreparationUIManager = gamePreparationUI.GetComponent<GamePreparationUIManager>();
        switchToMainMenuUI();
    }

    public void switchToMainMenuUI() { 
        gamePreparationUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        setupUI.SetActive(false);

        mainMenuUI.SetActive(true);
    }

    public void switchToLevelOverviewUI() {
        mainMenuUI.SetActive(false);
        gamePreparationUI.SetActive(false);
        setupUI.SetActive(false);

        levelOverviewUI.SetActive(true);
    }

    public void switchToGamePreparationUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        setupUI.SetActive(false);

        gamePreparationUI.SetActive(true);
    }

    public void switchToSetupUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);
        gamePreparationUI.SetActive(false);

        setupUI.SetActive(true);
    }
}
