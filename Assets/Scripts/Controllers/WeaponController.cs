using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletSpeed;
    public float bulletSpawnInterval;

    //Value, from which the input is processed and bullets are shoot
    public float verticalInputThreshold;

    private PlayerColorController playerColor;

    //private FixedJoystick joystick;
    private SoundManager soundManager;

    private FixedJoystick joystickRight;
    private FixedJoystick joystickLeft;

    private float bulletSpawnIntervalTimer;

    void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        playerColor = GameObject.Find("Player").GetComponent<PlayerColorController>();

        PlayerConfigurationManager configManager = 
            GameObject.Find("PlayerConfigurationManager").GetComponent<PlayerConfigurationManager>();

        if (SystemInfo.deviceType == DeviceType.Handheld) {
            joystickRight = GameObject.Find("MovementController").GetComponent<MovementController>().joystickRight;
            joystickLeft = GameObject.Find("MovementController").GetComponent<MovementController>().joystickLeft;
        }

        bulletPrefab = configManager.getSelectedBullet();
    }

    // Update is called once per frame
    void Update() {
        bulletSpawnIntervalTimer += Time.deltaTime;

        if ( (SystemInfo.deviceType == DeviceType.Handheld) && (joystickRight.isPressed || joystickLeft.isPressed) ) {
            shootBullet();
        } else if (Input.GetKey(KeyCode.Space)) {
            shootBullet();
        }
   
    }

    void shootBullet() {
        if (bulletSpawnIntervalTimer > bulletSpawnInterval) {
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            BulletBehaviour bulletBehaviour = bulletInstance.GetComponent<BulletBehaviour>();
            bulletBehaviour.bulletColor = playerColor.currentPlayerColor;
            bulletBehaviour.setBulletColor();

            soundManager.playShootSound();
            bulletSpawnIntervalTimer = 0f;
        } 
    }
}
