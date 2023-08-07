using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour {

    public EnemyShipWeaponController weaponController;
    public EnemyShipMovementController movementController;

    private GameObject player;

    void Start() {
        
    }


    void Update() {
        weaponController.shootEnemyBullet();
    }
}
