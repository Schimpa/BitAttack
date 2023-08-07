using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipWeaponController : WeaponControllerBase {


    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();

    }

    public void shootEnemyBullet() {
        base.shootBullet();
    }

}
