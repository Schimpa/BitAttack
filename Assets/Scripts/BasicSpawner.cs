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
    public bool preventSameSpawnPositionTwice;  // If this is true, the spawner does not spawn two objects after another at the same position

    private List<GameObject> spawnedObjects;
    private float deltaTime;

    private int previousSpawnPosition;

    void Awake() {

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
        deltaTime = 0f + spawnIntervalStartOffset;
        previousSpawnPosition = 100; // Random number that does not correspond to previos spawn position
        spawnedObjects = new List<GameObject>();
    }

}
