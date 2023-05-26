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

    //private FixedJoystick joystick;
    private SoundManager soundManager;

    private float bulletSpawnIntervalTimer;

    void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update() {
        bulletSpawnIntervalTimer += Time.deltaTime;

        float verticalInput = 0f;

        if (SystemInfo.deviceType == DeviceType.Handheld) {
            //verticalInput = joystick.Horizontal;
        } else {
            verticalInput = Input.GetAxis("Vertical");
        }

        if (verticalInput > verticalInputThreshold) {
            shootBullet();
        }
        
    }

    void shootBullet() {
        if (bulletSpawnIntervalTimer > bulletSpawnInterval) {
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            soundManager.playShootSound();
            bulletSpawnIntervalTimer = 0f;
        } 
    }
}
