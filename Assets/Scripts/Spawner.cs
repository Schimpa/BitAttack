using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsible for spawning gameobjects
 */
public class Spawner : MonoBehaviour {

    public List<Transform> spawnPoints;
    public GameObject spawnObjectPrefab;

    public float spawnInterval; // In Seconds
    public float spawnObjectMoveDownSpeedMultiplier;

    private List<GameObject> spawnedObjects;
    private float deltaTime;

    private float spawnIntervalDefault;
    private float spawnObjectMoveDownSpeedMultiplierDefault;

    void Awake() {
        spawnIntervalDefault = spawnInterval;
        spawnObjectMoveDownSpeedMultiplierDefault = spawnObjectMoveDownSpeedMultiplier;
    }
    void Start() {
        initValues();
    }

    // Update is called once per frame
    void Update() {
        deltaTime += Time.deltaTime;

        if (deltaTime > spawnInterval) {
            spawnNewObject();
            deltaTime = 0f;
        }

    }

    private void spawnNewObject() {
        int startPos = Random.Range(0, 3);

        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject newObject = Instantiate(spawnObjectPrefab, spawnPoints[startPos].position, Quaternion.identity);
        setNewObjectProperties(newObject);

        spawnedObjects.Add(newObject);
    }

    private void setNewObjectProperties(GameObject newObject) {
        ObstacleBehaviour obstacle = newObject.GetComponent<ObstacleBehaviour>();

        obstacle.moveDownSpeedY *= spawnObjectMoveDownSpeedMultiplier;
    }

    public void resetSpawner() {
        clearAllSpawnedObjects();
        initValues();
    }

    private void clearAllSpawnedObjects() { if (spawnedObjects == null) return;

        foreach(GameObject obj in spawnedObjects) {
            Destroy(obj);
        }
    }

    private void initValues() {
        deltaTime = 0f;
        spawnInterval = spawnIntervalDefault;
        spawnObjectMoveDownSpeedMultiplier = spawnObjectMoveDownSpeedMultiplierDefault;
        spawnedObjects = new List<GameObject>();
    }

}
