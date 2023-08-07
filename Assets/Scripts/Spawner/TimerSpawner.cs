using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsible for spawning gameobjects
 */
public class TimerSpawner : BasicSpawner {

    public float spawnInterval; // In Seconds
    public float spawnIntervalStartOffset;

    protected float deltaTime;

    void Start() {
        initValues();
    }


    protected override void Update() {
        base.Update();
        deltaTime += Time.deltaTime;

        if (deltaTime > spawnInterval) {
            for (int i = 0; i < spawnAmount; i++) {
                spawnNewObject();
            }
            deltaTime = 0f;
        }

    }
}
