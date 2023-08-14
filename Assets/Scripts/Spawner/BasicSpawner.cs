using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsible for spawning gameobjects
 */
public class BasicSpawner : MonoBehaviour {

    public List<Transform> spawnPoints;
    public GameObject spawnObjectPrefab;

    public int spawnAmount; // The amount of objects that shall be spawned at the same time
    public bool preventSameSpawnPositionTwice;  // If this is true, the spawner does not spawn two objects after another at the same position

    [Header("If this is not null, the particles will be spawned with the new object. \nThe particle gameobject " +
        "shall be set to be destroyed afterthe particle is finished playing")]
    public GameObject spawnParticle;

    private float spawnListClearInterval = 1f;
    private float spawnListClearIntervalTimer;

    protected List<GameObject> spawnedObjects;

    protected int previousSpawnPosition;

    protected virtual void Awake() {
        if (spawnAmount == 0) {
            spawnAmount = 1;
        }
        spawnListClearIntervalTimer = 0;
    }

    void Start() {
        initValues();
    }

    protected virtual void Update() {
        spawnListClearIntervalTimer += Time.deltaTime;

        if (spawnListClearIntervalTimer > spawnListClearInterval) {
            spawnListClearIntervalTimer = 0f;
            clearListOfDestroyedObjects();
        }
    }

    public void resetSpawner() {  
        if (spawnedObjects != null) {
            clearListOfDestroyedObjects();
            destroyAllSpawnedObjects();
        }      
        initValues();
    }

    public virtual void spawnNewObject() {
        int spawnPos = getSpawnPosition();

        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject newObject = Instantiate(spawnObjectPrefab, spawnPoints[spawnPos].position, Quaternion.identity);
        newObject.transform.rotation = this.transform.rotation;

        if (spawnParticle != null) {
            Instantiate(spawnParticle, spawnPoints[spawnPos].position, Quaternion.identity);
        }

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

    protected void destroyAllSpawnedObjects() {
        foreach(GameObject obj in spawnedObjects) {
            Destroy(obj);
        }
    }

    protected void clearListOfDestroyedObjects() {
        for (int i = 0; i < spawnedObjects.Count; i++) {
            if (spawnedObjects[i] == null) {
                spawnedObjects.RemoveAt(i);
            }
        }
    }

    protected virtual void initValues() {
        previousSpawnPosition = 100; // Random number that does not correspond to previos spawn position
        spawnedObjects = new List<GameObject>();
    }

    public int getSpawnedObjectsCount() {
        return spawnedObjects.Count;
    }

}
