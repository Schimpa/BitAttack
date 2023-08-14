using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles the collisions between the enemy ship object 
 * and the bullets from the player
 */
public class EnemyShipCollisionDetection : MonoBehaviour {

    [Header("The health points that the enemy ship has")]
    public int healthPoints;

    [Header("The destroy particle of the enemy ship")]
    public GameObject destroyParticle;

    private int currentHealthPoints;

    public BoxCollider2D col;

    private void Start() {
        currentHealthPoints = healthPoints;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet")) {

            BulletBehaviour bullet = collision.gameObject.GetComponent<BulletBehaviour>();
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playObstacleHitSound();

            currentHealthPoints -= bullet.damage;
            bullet.Destroy();

            if (currentHealthPoints <= 0) {
                Destroy();
            }       
        }      
    }

    private void Destroy() {
        Instantiate(destroyParticle,this.transform.position, destroyParticle.transform.rotation);
        Destroy(this.gameObject);
    }

}
