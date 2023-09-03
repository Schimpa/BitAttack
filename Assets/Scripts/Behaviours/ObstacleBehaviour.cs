using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {


    [Header("The down move speed in Y direction (towards the player)")]
    public float moveDownSpeedY;

    [Header("The position, at which this obstacle will be destoyed")]
    public float destroyPositionY;

    [Header("The amount of score the player gets if this obstacle is avoided")]
    public int scoreWhenAvoided = 25;

    [Header("The amount of score the player gets if this obstacle is shot")]
    public int scoreWhenShot = 50;

    [Header("The amount of bits the player gets if this obstacle is shot")]
    public int bitsWhenShot = 1;

    [Header("The health points the obstacle has, before it gets destroyed. Different bullets to different damage")]
    public int healthPoints = 10;

    [Header("The damage that the obstacle does to the player")]
    public int damage = 10;

    public Renderer obstacleRenderer;

    public ColorMode obstacleColor;

    [Header("Has to be in order BLUE, GREEN, PURPLE")]
    public List<GameObject> obstacleTrails;

    public Transform trailSpawnTransform;

    [Header("Has to be in order BLUE, GREEN, PURPLE")]
    public List<GameObject> obstacleDestroyParticles;

    private GameStatsManager gameStats;

    private int currentHealthPoints;


    private void Start() {
        gameStats = GameObject.Find("GameStatsManager").GetComponent<GameStatsManager>();
        currentHealthPoints = healthPoints;
        setObstacleColor();
        spawnObstacleTrail();
    }
    private void Update() {
        checkDestroyConditions();
        translateObstacle();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet")){

            GameObject playerObj = GameObject.Find("Player");
            PlayerColorController playerColor = playerObj.GetComponent<PlayerColorController>();


            if (playerColor.currentPlayerColor == obstacleColor) {

                currentHealthPoints -= collision.gameObject.GetComponent<BulletBehaviour>().damage;

                if (currentHealthPoints <= 0) {
                    destroyObstacleFromBullet();
                    playerColor.changePlayerColor();
                } else {
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().playObstacleHitSound();
                }
               
                collision.gameObject.GetComponent<BulletBehaviour>().Destroy();
            }
        } else if (collision.CompareTag("Player")){
            destroyObstacleFromPlayerCollision();
        }
    }

    private void checkDestroyConditions() {
        if (transform.position.y < destroyPositionY) {
            destroyObstacleFromBorder();
        }
    }

    private void destroyObstacleFromPlayerCollision() {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playObstacleHitSound();
        spawnObstacleDestroyParticles();
        Destroy(this.gameObject);
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

        GameObject.Find("SoundManager").GetComponent<SoundManager>().playObstacleDestroyedSound();
        spawnObstacleDestroyParticles();

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
                colorController.setColoGreend(obstacleRenderer.material);
                obstacleColor = ColorMode.GREEN;
                break;
            case 2:
                colorController.setColorPurple(obstacleRenderer.material);
                obstacleColor = ColorMode.PURPLE;
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
            case ColorMode.GREEN:
                trail = Instantiate(obstacleTrails[1], trailSpawnTransform.position, Quaternion.identity);
                break;
            case ColorMode.PURPLE:
                trail = Instantiate(obstacleTrails[2], trailSpawnTransform.position, Quaternion.identity);
                break;
            default:
                trail = Instantiate(obstacleTrails[0], trailSpawnTransform.position, Quaternion.identity); 
                break;
        }

        trail.transform.SetParent(this.gameObject.transform);
    }

    private void spawnObstacleDestroyParticles() {
        GameObject destroyParticle;
        switch (obstacleColor) {
            case ColorMode.BLUE:
                destroyParticle = Instantiate(obstacleDestroyParticles[0], 
                    this.transform.position, obstacleDestroyParticles[0].transform.rotation);
                break;
            case ColorMode.GREEN:
                destroyParticle = Instantiate(obstacleDestroyParticles[1], 
                    this.transform.position, obstacleDestroyParticles[1].transform.rotation);
                break;
            case ColorMode.PURPLE:
                destroyParticle = Instantiate(obstacleDestroyParticles[2], 
                    this.transform.position, obstacleDestroyParticles[2].transform.rotation);
                break;
            default:
                destroyParticle = Instantiate(obstacleDestroyParticles[0], 
                    this.transform.position, obstacleDestroyParticles[0].transform.rotation);
                break;
        }

    }

}
