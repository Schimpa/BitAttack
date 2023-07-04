using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverviewUIManager : MonoBehaviour {


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void setUpStage1ForGamePreparationUI() {
        GamePreparationUIManager gamePrep = 
            GameObject.Find("Canvas").GetComponent<MainScreenUIManager>().getGamePreparationUIManager();

        gamePrep.configureUI("Stage01");

    }
}
