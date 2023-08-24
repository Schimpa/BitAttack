using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsible for spawning the obstacles
 * that move towards the player
 */
public class ObstacleSpawner : TimerSpawner {

    [Header("PC = All five spawn points are used, MOBILE = Only three are used")]
    public GameMode gameMode;

    public float spawnObjectMoveDownSpeedMultiplier;

    [Header("Spawner Level Up Properties")]
    public float spawnerIntervalMultiplier;
    public float obstacleSpeedMultiplier;

    private float spawnIntervalDefault;
    private float spawnObjectMoveDownSpeed;
    private float spawnObjectMoveDownSpeedMultiplierDefault;

    private int previousSpawnPoint;

    protected override void Awake() {
        base.Awake();
        spawnObjectMoveDownSpeed = 1;
        spawnIntervalDefault = spawnInterval;
        spawnObjectMoveDownSpeedMultiplierDefault = spawnObjectMoveDownSpeedMultiplier;
        if (gameMode == GameMode.MOBILE) {
            //Do not use the outer two spawn points
            spawnPoints.RemoveAt(4);
            spawnPoints.RemoveAt(3);
        }
    }

    void Start() {
        initValues();
    }

    protected override void Update() {
        base.Update();
    }

    private int getSpawnPosition() {
        int spawnPos = Random.Range(0, spawnPoints.Count);

        while (preventSameSpawnPositionTwice && spawnPos == previousSpawnPoint) {
            //Prevent same spawn position twice
            spawnPos = Random.Range(0, spawnPoints.Count);
        }

        previousSpawnPoint = spawnPos;
        return spawnPos;
    }

    public override void spawnNewObject() {
        setNewSpawnPositionListPosition();

        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject newObject = Instantiate(
            spawnObjectPrefabs[spawnObjectListPosition],
            spawnPoints[spawnPositionListPosition].position,
            Quaternion.identity);

        newObject.transform.rotation = this.transform.rotation;

        if (spawnParticle != null) {
            Instantiate(
                spawnParticle,
                spawnPoints[spawnPositionListPosition].position,
                Quaternion.identity);
        }

        setObstacleProperties(newObject);

        spawnedObjects.Add(newObject);
        setNewSpawnObjectListPosition();

        
    }

    private void setObstacleProperties(GameObject newObject) {
        ObstacleBehaviour obstacle = newObject.GetComponent<ObstacleBehaviour>();
        obstacle.moveDownSpeedY *= spawnObjectMoveDownSpeedMultiplier;

        if (spawnObjectMoveDownSpeed != 1) {    //Special handling for the arcade mode where initial speed is determined in menu
            obstacle.moveDownSpeedY = spawnObjectMoveDownSpeed * spawnObjectMoveDownSpeedMultiplier;
        }
    }

    public void levelUp() {
        // Levels up the spawner and adjusts properties
        spawnInterval *= spawnerIntervalMultiplier;
        spawnObjectMoveDownSpeedMultiplier *= obstacleSpeedMultiplier;
    }

    protected override void initValues() {
        base.initValues();
        spawnInterval = spawnIntervalDefault;
        spawnObjectMoveDownSpeedMultiplier = spawnObjectMoveDownSpeedMultiplierDefault;
    }

    public void loadArcadePreferenceValues() {

        float spawnInterval = PlayerPrefs.GetFloat(ArcadeKeys.SPAWN_INTERVAL.ToString());
        float spawnIntervalMultiplier = PlayerPrefs.GetFloat(ArcadeKeys.SPAWN_INTERVAL_MULTIPLIER.ToString());
        float bitSpeed = PlayerPrefs.GetFloat(ArcadeKeys.BIT_SPEED.ToString());
        float bitSpeedMultiplier = PlayerPrefs.GetFloat(ArcadeKeys.BIT_SPEED_MULTIPLIER.ToString());

        this.spawnInterval = spawnInterval;
        this.spawnIntervalDefault = spawnInterval;
        this.spawnerIntervalMultiplier = spawnIntervalMultiplier;
        this.obstacleSpeedMultiplier = bitSpeedMultiplier;
        this.spawnObjectMoveDownSpeedMultiplier = bitSpeedMultiplier;
        this.spawnObjectMoveDownSpeedMultiplierDefault = bitSpeedMultiplier;
        this.spawnObjectMoveDownSpeed = bitSpeed;

    }

}
