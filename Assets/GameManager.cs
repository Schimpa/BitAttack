using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


/**
 * Wofür soll dieses Skript zuständing sein?
 * - Den Spawner kontrollieren, Spawnrate und Geschwindigkeit einstellen
 * - Spielzeit, Score und Level verwalten
 * - Spiel starten / beenden
 * 
 */
public class GameManager : MonoBehaviour {

    [Header("Game Object References")]
    public Spawner spawner;

    [Header("UI References")]
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text timeText;

    [Header("Game Parameters")]
    public float playTime;
    public int score;
    public int level;
    public int levelUpTime = 10;   // The Time it takes to level up

    [Header("Spawner Properties")]
    public float spawnerIntervalMultiplier;
    public float obstacleSpeedMultiplier;


    private float levelUpTimer;

    void Start() {
        playTime = 0f;
    }

    // Update is called once per frame
    void Update() {
        checkLevel();
        updateUI();
        playTime += Time.deltaTime;
        score += 1;
    }

    private void checkLevel() {
        levelUpTimer += Time.deltaTime;
        if (levelUpTimer >= levelUpTime) {
            levelUpTimer = 0f;
            level++;
            updateSpawnerProperties();
        }
    }

    private void updateSpawnerProperties() {
        /**
        * Updates the spawner properties with the specified multipliers
        */
        spawner.spawnInterval *= spawnerIntervalMultiplier;
        spawner.spawnObjectMoveDownSpeedMultiplier *= obstacleSpeedMultiplier;
    }

    private void updateUI() {
        scoreText.text = score.ToString();
        timeText.text = System.Math.Round(playTime,2).ToString();
    }
}
