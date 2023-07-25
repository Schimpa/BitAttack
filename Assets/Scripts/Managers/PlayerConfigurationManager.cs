using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class is responsible for player configurations like selected ship or bullet
 */

public class PlayerConfigurationManager : MonoBehaviour {

    public GlobalStatsFileManager globalStatsFileManager;

    public Mesh ship01;
    public Mesh ship02;
    public Mesh ship03;

    public GameObject bullet01;
    public GameObject bullet02;
    public GameObject bullet03;

    private GlobalStats globalStats;

    private int selectedShip;

    private int selectedBullet;


    void Start() {
        globalStatsFileManager.loadStats();

        globalStats = globalStatsFileManager.getGlobalStats();

        //selectedShip = 0;
        //selectedBullet = 0;

        selectedShip = globalStats.selectedShip;
        selectedBullet = globalStats.selectedBullet;
    }


    public Mesh getSelectedShip() {
        switch (selectedShip) {
            case 0:
                return ship01;
            case 1:
                return ship02;
            case 2:
                return ship03;
            default:
                Debug.LogError("Error when selecting ship!");
                return null;
        }
    }

    public GameObject getSelectedBullet() {
        switch (selectedBullet) {
            case 0:
                return bullet01;
            case 1:
                return bullet02;
            case 2:
                return bullet03;
            default:
                Debug.LogError("Error when selecting bullet!");
                return null;
        }
    }
}
