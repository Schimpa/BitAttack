using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles the collisions between the player object 
 * and other objects in the world
 */
public class PlayerCollisionDetection : MonoBehaviour {

    [Header("The health points that the player has")]
    public int playerHealthPoints;

    private int currentHealthPoints;

    public BoxCollider2D col;

    private void Start() {
        ResetStats();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Obstacle")) {
            handleObstacleCollision(collision);
        } else if (collision.CompareTag("Bullet")) {
            handleBulletCollision(collision);
        }      
    }

    private void handleObstacleCollision(Collider2D collision) {
        ObstacleBehaviour obst = collision.gameObject.GetComponent<ObstacleBehaviour>();
        currentHealthPoints -= obst.damage;

        if (currentHealthPoints <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void handleBulletCollision(Collider2D collision) {
        BulletBehaviour bullet = collision.gameObject.GetComponent<BulletBehaviour>();

        currentHealthPoints -= bullet.damage;
        bullet.Destroy();

        if (currentHealthPoints <= 0) {
            Destroy(this.gameObject);
        }
    }


    public void setPlayerHealthPoints(int value) {
        playerHealthPoints = value;
        currentHealthPoints = value;
    }

    public void ResetStats() {
        PlayerConfigurationManager playerConfigManager
            = GameObject.Find("PlayerConfigurationManager").GetComponent<PlayerConfigurationManager>();

        currentHealthPoints = playerHealthPoints;
    }

}
