using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    // The down move speed in Y direction (towards the player)
    public float moveDownSpeedY;

    // The position, at which this obstacle will be destoyed
    public float destroyPositionY;

    // The amount of score it adds to the game if this obstacle is destroyed
    public int score = 100;

    void Update() {
        checkDestroyConditions();
        translateObstacle();
    }

    private void checkDestroyConditions() {
        if (transform.position.y < destroyPositionY) {
            GameStatsManager gameStats = GameObject.Find("GameStatsManager").GetComponent<GameStatsManager>();
            gameStats.addScore(score);
            gameStats.currentObstaclesAvoided++;
            Destroy(this.gameObject);
        }
    }

    private void translateObstacle() {
        Vector3 moveVector = new Vector3(0, -moveDownSpeedY, 0) * moveDownSpeedY * Time.deltaTime;
        transform.Translate(moveVector);
    }

}
