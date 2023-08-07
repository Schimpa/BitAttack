using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : WeaponControllerBase {

    //Value, from which the input is processed and bullets are shoot
    public float verticalInputThreshold;

    private PlayerColorController playerColor;

    private PlayerConfigurationManager playerConfigManager;

    private FixedJoystick joystickRight;
    private FixedJoystick joystickLeft;

    protected override void Start() {
        base.Start();
        playerColor = GameObject.Find("Player").GetComponent<PlayerColorController>();

        playerConfigManager = 
            GameObject.Find("PlayerConfigurationManager").GetComponent<PlayerConfigurationManager>();

        bulletPrefab = playerConfigManager.getSelectedBullet();

        BulletBehaviour bulletBehav = bulletPrefab.GetComponent<BulletBehaviour>();
        bulletSpawnInterval = bulletBehav.spawnInterval;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();

        if ( (SystemInfo.deviceType == DeviceType.Handheld) && (joystickRight.isPressed || joystickLeft.isPressed) ) {
            shootBullet();
        } else if (Input.GetKey(KeyCode.Space)) {
            shootBullet();
        }
   
    }

    protected override void shootBullet() {
        if (bulletSpawnIntervalTimer > bulletSpawnInterval) {
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            BulletBehaviour bulletBehaviour = bulletInstance.GetComponent<BulletBehaviour>();
            bulletBehaviour.color = playerColor.currentPlayerColor;
            bulletBehaviour.setBulletColor();

            playShootSound();
            bulletSpawnIntervalTimer = 0f;
        } 
    }

    protected override void playShootSound() {
        int shootSoundSelection = playerConfigManager.getSelectedBulletNumber();

        switch (shootSoundSelection) {
            case 0:
                soundManager.playShootSound01();
                break;
            case 1:
                soundManager.playShootSound02();
                break;
            case 2:
                soundManager.playShootSound03();
                break;
            default:
                soundManager.playShootSound01();
                break;
        }

    }
}
