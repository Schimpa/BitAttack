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

    public Renderer obstacleRenderer;

    public ColorMode obstacleColor;


    private void Start() {
        setObstacleColor();
    }
    private void Update() {
        checkDestroyConditions();
        translateObstacle();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet") == false) return;

        PlayerColorController playerColor = GameObject.Find("Player").GetComponent<PlayerColorController>();

        if (playerColor.currentPlayerColor == obstacleColor) {
            destroyObstacleFromBullet();
        }
    }

    private void checkDestroyConditions() {
        if (transform.position.y < destroyPositionY) {
            destroyObstacleFromBorder();
        }
    }

    private void destroyObstacleFromBorder() {
        GameStatsManager gameStats = GameObject.Find("GameStatsManager").GetComponent<GameStatsManager>();
        gameStats.addScore(score);
        gameStats.currentObstaclesAvoided++;
        Destroy(this.gameObject);
    }

    private void destroyObstacleFromBullet() {
        GameStatsManager gameStats = GameObject.Find("GameStatsManager").GetComponent<GameStatsManager>();
        gameStats.addScore(score);
        gameStats.addCoins(1);
        gameStats.currentObstaclesAvoided++;
        Destroy(this.gameObject);
    }

    private void translateObstacle() {
        Vector3 moveVector = new Vector3(0, -moveDownSpeedY, 0) * moveDownSpeedY * Time.deltaTime;
        transform.Translate(moveVector);
    }

    private void setObstacleColor() {
        ColorController colorController = GameObject.Find("ColorController").GetComponent<ColorController>();
        int colorNum = Random.Range(0, 3);

        switch (colorNum) {
            case 0:
                colorController.setColorBlue(obstacleRenderer.material);
                obstacleColor = ColorMode.BLUE;
                break;
            case 1:
                colorController.setColorRed(obstacleRenderer.material);
                obstacleColor = ColorMode.RED;
                break;
            case 2:
                colorController.setColorYellow(obstacleRenderer.material);
                obstacleColor = ColorMode.YELLOW;
                break;

        }
    }

}
