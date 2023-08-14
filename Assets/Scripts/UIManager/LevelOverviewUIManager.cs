using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOverviewUIManager : MonoBehaviour {

    public GlobalStatsFileManager globalStatsFileManager;

    public Button level01Button;

    void Start() {
        GlobalStats globalStats = globalStatsFileManager.getGlobalStats();

        if (globalStats.level01Unlocked) {
            level01Button.interactable = true;
        } else {
            level01Button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
