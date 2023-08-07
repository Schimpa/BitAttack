using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControllerBase : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletSpawnInterval;

    protected SoundManager soundManager;

    protected float bulletSpawnIntervalTimer;

    protected virtual void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        BulletBehaviour bulletBehav = bulletPrefab.GetComponent<BulletBehaviour>();
        bulletSpawnInterval = bulletBehav.spawnInterval;
    }

    // Update is called once per frame
    protected virtual void Update() {
        bulletSpawnIntervalTimer += Time.deltaTime;
    }

    protected virtual void shootBullet() {
        if (bulletSpawnIntervalTimer > bulletSpawnInterval) {
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            BulletBehaviour bulletBehaviour = bulletInstance.GetComponent<BulletBehaviour>();
            bulletBehaviour.setBulletColor();

            playShootSound();
            bulletSpawnIntervalTimer = 0f;
        } 
    }

    protected virtual void playShootSound() { soundManager.playShootSound01(); }
    
}
