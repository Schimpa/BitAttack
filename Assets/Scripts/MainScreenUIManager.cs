using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenUIManager : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject levelOverviewUI;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void switchToMainMenuUI() {
        mainMenuUI.SetActive(true);
        levelOverviewUI.SetActive(false);
    }

    public void switchToLevelOverviewUI() {
        mainMenuUI.SetActive(false);
        levelOverviewUI.SetActive(true);
    }
}
