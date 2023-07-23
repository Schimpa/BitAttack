using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    
    public float moveDownSpeedY; // The down move speed in Y direction (towards the player)
    public float destroyPositionY; // The position, at which this obstacle will be destoyed

    public int scoreWhenAvoided = 25; // The amount of score the player gets if this obstacle is avoided
    public int scoreWhenShot = 50; // The amount of score the player gets if this obstacle is shot
    public int bitsWhenShot = 1; // The amount of bits the player gets if this obstacle is shot

    public Renderer obstacleRenderer;

    public ColorMode obstacleColor;

    [Header("Has to be in order BLUE, RED, YELLOW")]
    public List<GameObject> obstacleTrails;

    public Transform trailSpawnTransform;

    private GameStatsManager gameStats;


    private void Start() {
        gameStats = GameObject.Find("GameStatsManager").GetComponent<GameStatsManager>();
        setObstacleColor();
        spawnObstacleTrail();
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
        gameStats.addBits(bitsWhenShot);
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

    private void spawnObstacleTrail() {
        // Spawns the obstacle trail, depending on the color
        GameObject trail;
        switch (obstacleColor) {
            case ColorMode.BLUE:
                trail = Instantiate(obstacleTrails[0], trailSpawnTransform.position, Quaternion.identity);
                break;
            case ColorMode.RED:
                trail = Instantiate(obstacleTrails[1], trailSpawnTransform.position, Quaternion.identity);
                break;
            case ColorMode.YELLOW:
                trail = Instantiate(obstacleTrails[2], trailSpawnTransform.position, Quaternion.identity);
                break;
            default:
                trail = Instantiate(obstacleTrails[0], trailSpawnTransform.position, Quaternion.identity); 
                break;
        }

        trail.transform.SetParent(this.gameObject.transform);
    }

}
