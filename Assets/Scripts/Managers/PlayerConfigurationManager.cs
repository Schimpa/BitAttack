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

    public float ship01MoveSpeed = 1;
    public float ship02MoveSpeed = 1.3f;
    public float ship03MoveSpeed = 0.7f;

    public int ship01Health = 10;
    public int ship02Health = 7;
    public int ship03Health = 20;

    private GlobalStats globalStats;

    private int selectedShip;

    private int selectedBullet;

    private bool isLoaded = false;


    void Start() {
        globalStatsFileManager.loadStats();

        globalStats = globalStatsFileManager.getGlobalStats();

        selectedShip = globalStats.selectedShip;
        selectedBullet = globalStats.selectedBullet;

        isLoaded = true;
    }


    public Mesh getSelectedShip() {
        switch (selectedShip) {
            case 0: return ship01;
            case 1: return ship02;
            case 2: return ship03;
            default: Debug.LogError("Error when selecting ship!"); return null;
        }
    }

    public float getSelectedShipMoveSpeed() {
        switch (selectedShip) {
            case 0: return ship01MoveSpeed;
            case 1: return ship02MoveSpeed;
            case 2: return ship03MoveSpeed;
            default: Debug.LogError("Error when selecting ship!"); return 1;
        }
    }

    public int getSelectedShipHealth() {
        switch (selectedShip) {
            case 0: return ship01Health;
            case 1: return ship02Health;
            case 2: return ship03Health;
            default: Debug.LogError("Error when selecting ship!"); return 1;
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
