using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Obstacle used for background. Does not interact with anything in the game
 */
public class BackgroundObstacleBehaviour : MonoBehaviour {

   
    public float moveSpeed; // The down move speed in Y direction 
    public float destroyDistance; // The distance, at which this obstacle will be destoyed

    public Renderer obstacleRenderer;

    public GameObject obstacleDestroyParticle;

    private Vector3 spawnPosition;

    private void Start() {
        spawnPosition = this.transform.position;
    }

    private void Update() {
        checkDestroyConditions();
        translateObstacle();
    }

    private void checkDestroyConditions() {
        Vector3 currentPosition = this.transform.position;
        float currentDistance = Vector3.Distance(spawnPosition, currentPosition);

        if (currentDistance > destroyDistance) {
            destroyObstacle();
        }
    }

    private void destroyObstacle() {
        Destroy(this.gameObject);
    }

    private void translateObstacle() {
        Vector3 moveVector = new Vector3(0, -moveSpeed, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        Instantiate(obstacleDestroyParticle,
                    this.transform.position, obstacleDestroyParticle.transform.rotation);

        Destroy(this.gameObject);
    }

}
