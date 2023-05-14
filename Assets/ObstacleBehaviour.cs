using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    // The down move speed in Y direction (towards the player)
    public float moveDownSpeedY;

    // The position, at which this obstacle will be destoyed
    public float destroyPositionY;

    void Update() {
        if (transform.position.y < destroyPositionY) {
            Destroy(this.gameObject);
        }

        Vector3 moveVector = new Vector3(0, -moveDownSpeedY, 0) * moveDownSpeedY * Time.deltaTime;

        transform.Translate(moveVector);

    }



}
