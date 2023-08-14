using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is responsible for player configurations like selected ship or bullet
 */

public class PlayerConfigurationManager : MonoBehaviour {

    public GlobalStatsFileManager globalStatsFileManager;

    public GameObject ship01;
    public GameObject ship02;
    public GameObject ship03;

    public GameObject bullet01;
    public GameObject bullet02;
    public GameObject bullet03;

    private GlobalStats globalStats;

    private int selectedShip;

    private int selectedBullet;

    private bool isLoaded = false;


    void Start() {
        globalStats = globalStatsFileManager.getGlobalStats();

        selectedShip = globalStats.selectedShip;
        selectedBullet = globalStats.selectedBullet;

        isLoaded = true;
    }


    public GameObject getSelectedShip() {
        switch (selectedShip) {
            case 0: return ship01;
            case 1: return ship02;
            case 2: return ship03;
            default: Debug.LogError("Error when selecting ship!"); return null;
        }
    }

    public GameObject getSelectedBullet() {
        switch (selectedBullet) {
            case 0: return bullet01;
            case 1: return bullet02;
            case 2: return bullet03;
            default: Debug.LogError("Error when selecting bullet!"); return null;
        }
    }

    public int getSelectedShipNumber() {
        return this.selectedShip;
    }

    public int getSelectedBulletNumber() {
        return this.selectedBullet;
    }

    public bool isConfigurationLoaded() {
        return this.isLoaded;
    }
}
