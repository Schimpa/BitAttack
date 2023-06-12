using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenUIManager : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject levelOverviewUI;
    public GameObject gamePreparationUI;

    public GamePreparationUIManager gamePreparationUIManager;

    void Start() {
        gamePreparationUIManager = gamePreparationUI.GetComponent<GamePreparationUIManager>();
        switchToMainMenuUI();
    }

    public void switchToMainMenuUI() { 
        gamePreparationUI.SetActive(false);
        levelOverviewUI.SetActive(false);

        mainMenuUI.SetActive(true);
    }

    public void switchToLevelOverviewUI() {
        mainMenuUI.SetActive(false);
        gamePreparationUI.SetActive(false);

        levelOverviewUI.SetActive(true);
    }

    public void switchToGamePreparationUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(false);

        gamePreparationUI.SetActive(true);
    }
}
