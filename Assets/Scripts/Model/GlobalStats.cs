using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalStats {

    public int coins;

    public bool ship01Unlocked;
    public bool ship02Unlocked;
    public bool ship03Unlocked;

    public bool bullet01Unlocked;
    public bool bullet02Unlocked;
    public bool bullet03Unlocked;

    public bool exhaust01Unlocked;
    public bool exhaust02Unlocked;
    public bool exhaust03Unlocked;

    public int selectedShip;
    public int selectedBullet;

    public GlobalStats() {

        this.coins = 0;

        this.ship01Unlocked = false;
        this.ship02Unlocked = false;
        this.ship03Unlocked = false;

        this.bullet01Unlocked = false;
        this.bullet02Unlocked = false;
        this.bullet03Unlocked = false;

        this.exhaust01Unlocked = false;
        this.exhaust02Unlocked = false;
        this.exhaust03Unlocked = false;

        this.selectedShip = 0;
        this.selectedBullet = 0;
    }


}
