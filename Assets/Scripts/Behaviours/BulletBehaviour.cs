using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    [Header("The up movespeed in Y direction")]
    public float moveSpeed;

    [Header("The distance, at which this bullet will be destoyed")]
    public float destroyDistance;

    [Header("The damage that the bullet does to the obstacles")]
    public int damage = 10;

    [Header("The interval at which new bullets will be spawned")]
    public float spawnInterval = 0.33f;

    public ColorMode color;

    [Header("Has to be in order BLUE, GREEN, PURPLE")]
    public List<GameObject> bulletTrails;

    [Header("Has to be in order BLUE, GREEN, PURPLE")]
    public List<GameObject> destroyParticles;

    private Vector2 startPos;

    private void Start() {
        setBulletColor();
        startPos = transform.position;
    }

    void Update() {
        checkDistance();
        moveBullet();
    }

    private void moveBullet() {
        Vector3 moveVector = new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector);
    }

    private void checkDistance() {
        Vector2 currentPos = transform.position;

        if (Vector2.Distance(currentPos, startPos) > destroyDistance) {
            Destroy(this.gameObject);
        }
    }


    public void setBulletColor() {
        GameObject trail;
        switch (color) {
            case ColorMode.BLUE:
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                trail = Instantiate(bulletTrails[0], this.transform.position, Quaternion.identity);
                break;
            case ColorMode.GREEN:
                this.GetComponent<SpriteRenderer>().color = Color.green;
                trail = Instantiate(bulletTrails[1], this.transform.position, Quaternion.identity);
                break;
            case ColorMode.PURPLE:
                this.GetComponent<SpriteRenderer>().color = Color.magenta;
                trail = Instantiate(bulletTrails[2], this.transform.position, Quaternion.identity);
                break;
            default:
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                trail = Instantiate(bulletTrails[0], this.transform.position, Quaternion.identity);
                break;
        }

        trail.transform.SetParent(this.gameObject.transform);
    }

    public void Destroy() {
        spawnBulletDestroyParticles();
        Destroy(this.gameObject);
    }

    private void spawnBulletDestroyParticles() {
        GameObject destroyParticle;
        switch (color) {
            case ColorMode.BLUE:
                destroyParticle = Instantiate(destroyParticles[0],
                    this.transform.position, destroyParticles[0].transform.rotation);
                break;
            case ColorMode.GREEN:
                destroyParticle = Instantiate(destroyParticles[1],
                    this.transform.position, destroyParticles[1].transform.rotation);
                break;
            case ColorMode.PURPLE:
                destroyParticle = Instantiate(destroyParticles[2],
                    this.transform.position, destroyParticles[2].transform.rotation);
                break;
            default:
                destroyParticle = Instantiate(destroyParticles[0],
                    this.transform.position, destroyParticles[0].transform.rotation);
                break;
        }

    }

}
