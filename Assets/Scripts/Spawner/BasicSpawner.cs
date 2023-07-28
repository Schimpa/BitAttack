using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsible for spawning gameobjects
 */
public class BasicSpawner : MonoBehaviour {

    public List<Transform> spawnPoints;
    public GameObject spawnObjectPrefab;

    public float spawnInterval; // In Seconds
    public float spawnIntervalStartOffset;
    public int spawnAmount; // The amount of objects that shall be spawned at the same time
    public bool preventSameSpawnPositionTwice;  // If this is true, the spawner does not spawn two objects after another at the same position

    protected List<GameObject> spawnedObjects;
    protected float deltaTime;

    protected int previousSpawnPosition;

    protected virtual void Awake() {
        if (spawnAmount == 0) {
            spawnAmount = 1;
        }
    }

    void Start() {
        initValues();
    }

    public void resetSpawner() {
        clearAllSpawnedObjects();
        initValues();
    }

    protected virtual void Update() {
        deltaTime += Time.deltaTime;

        if (deltaTime > spawnInterval) {
            for (int i = 0; i < spawnAmount; i++) {
                spawnNewObject();
            }
            deltaTime = 0f;
        }

    }

    protected virtual void spawnNewObject() {
        int spawnPos = getSpawnPosition();

        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject newObject = Instantiate(spawnObjectPrefab, spawnPoints[spawnPos].position, Quaternion.identity);
        newObject.transform.rotation = this.transform.rotation;

        spawnedObjects.Add(newObject);
    }

    private int getSpawnPosition() {
        int spawnPos = Random.Range(0, spawnPoints.Count);

        while (preventSameSpawnPositionTwice && spawnPos == previousSpawnPosition) {
            //Prevent same spawn position twice
            spawnPos = Random.Range(0, spawnPoints.Count);
        }

        previousSpawnPosition = spawnPos;
        return spawnPos;
    }

    protected void clearAllSpawnedObjects() { if (spawnedObjects == null) return;
        foreach(GameObject obj in spawnedObjects) {
            Destroy(obj);
        }
    }

    protected virtual void initValues() {
        deltaTime = 0f + spawnIntervalStartOffset;
        previousSpawnPosition = 100; // Random number that does not correspond to previos spawn position
        spawnedObjects = new List<GameObject>();
    }

}
