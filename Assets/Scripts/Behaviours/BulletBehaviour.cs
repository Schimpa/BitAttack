using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    // The upp move speed in Y direction
    public float moveSpeed;

    // The position, at which this obstacle will be destoyed
    public float destroyPositionY;

    public ColorMode bulletColor;

    [Header("Has to be in order BLUE, GREEN, PURPLE")]
    public List<GameObject> bulletTrails;

    private void Start() {
        setBulletColor();
    }

    void Update() {
        if (transform.position.y > destroyPositionY) {
            Destroy(this.gameObject);
        }
        Vector3 moveVector = new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector);

    }

    public void setBulletColor() {
        GameObject trail;
        switch (bulletColor) {
            case ColorMode.BLUE:
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                trail = Instantiate(bulletTrails[0], this.transform.position, Quaternion.identity);
                break;
            case ColorMode.GREEN:
                this.GetComponent<SpriteRenderer>().color = Color.green;
                trail = Instantiate(bulletTrails[1], this.transform.position, Quaternion.identity);
                break;
            case ColorMode.PURPLE:
                this.GetComponent<SpriteRenderer>().color = Color.blue * Color.red;
                trail = Instantiate(bulletTrails[2], this.transform.position, Quaternion.identity);
                break;
            default:
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                trail = Instantiate(bulletTrails[0], this.transform.position, Quaternion.identity);
                break;
        }

        trail.transform.SetParent(this.gameObject.transform);
    }

}
