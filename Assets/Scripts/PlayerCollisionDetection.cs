using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class handles the collisions between the player object 
 * and other objects in the world
 */
public class PlayerCollisionDetection : MonoBehaviour {

    public BoxCollider2D col;
    void Start() {
        
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(this.gameObject);
    }

}
