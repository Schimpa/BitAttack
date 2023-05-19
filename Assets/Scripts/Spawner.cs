using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is responsible for spawning gameobjects
 */
public class Spawner : MonoBehaviour {

    public List<Transform> spawnPoints;
    public GameObject spawnObject;

    public float spawnInterval; // In Seconds
    public float spawnObjectMoveDownSpeedMultiplier;

    private float deltaTime;

    // Start is called before the first frame update
    void Start() {
        deltaTime = 0f;
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
        GameObject newObject = Instantiate(spawnObject, spawnPoints[startPos].position, Quaternion.identity);

        setNewObjectProperties(newObject);
    }

    private void setNewObjectProperties(GameObject newObject) {
        ObstacleBehaviour obstacle = newObject.GetComponent<ObstacleBehaviour>();

        obstacle.moveDownSpeedY *= spawnObjectMoveDownSpeedMultiplier;
    }
}
