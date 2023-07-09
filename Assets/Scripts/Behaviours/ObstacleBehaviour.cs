using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    
    public float moveDownSpeedY; // The down move speed in Y direction (towards the player)
    public float destroyPositionY; // The position, at which this obstacle will be destoyed

    public int scoreWhenAvoided = 25; // The amount of score the player gets if this obstacle is avoided
    public int scoreWhenShot = 50; // The amount of score the player gets if this obstacle is shot
    public int coinsWhenShot = 1; // The amount of coins the player gets if this obstacle is shot

    public Renderer obstacleRenderer;

    public ColorMode obstacleColor;

    private GameStatsManager gameStats;


    private void Start() {
        gameStats = GameObject.Find("GameStatsManager").GetComponent<GameStatsManager>();
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
        gameStats.addScore(scoreWhenAvoided);
        gameStats.currentObstaclesAvoided++;
        Destroy(this.gameObject);
    }

    private void destroyObstacleFromBullet() {
        gameStats.addScore(scoreWhenShot);
        gameStats.addCoins(coinsWhenShot);
        gameStats.currentObstaclesAvoided++;

        GameObject.Find("SoundManager").GetComponent<SoundManager>().playObstacleHitSound();

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
