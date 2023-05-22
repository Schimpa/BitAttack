using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    // The upp move speed in Y direction
    public float moveSpeed;

    // The position, at which this obstacle will be destoyed
    public float destroyPositionY;

    void Update() {
        if (transform.position.y > destroyPositionY) {
            Destroy(this.gameObject);
        }

        Vector3 moveVector = new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;

        transform.Translate(moveVector);

    }

}
