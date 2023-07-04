using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour {

    public const int SHIP01_COINS = 100;
    public const int SHIP02_COINS = 200;
    public const int SHIP03_COINS = 400;

    public const int BULLET01_COINS = 100;
    public const int BULLET02_COINS = 200;
    public const int BULLET03_COINS = 400;

    public const int EXHAUST01_COINS = 100;
    public const int EXHAUST02_COINS = 200;
    public const int EXHAUST03_COINS = 400;

    public GlobalStatsFileManager globalStats;
    public TMPro.TMP_Text coinsText;

    public GameObject ship01Button;
    public GameObject ship02Button;
    public GameObject ship03Button;

    public GameObject bullet01Button;
    public GameObject bullet02Button;
    public GameObject bullet03Button;

    public GameObject exhaust01Button;
    public GameObject exhaust02Button;
    public GameObject exhaust03Button;

    private GlobalStats stats;

    void OnEnable() {
        globalStats.loadStats();
        stats = globalStats.getGlobalStats();

        updateCoinsText();

        checkShip01Button();
        checkShip02Button();
        checkShip03Button();

        checkBullet01Button();
        checkBullet02Button();
        checkBullet03Button();

        checkExhaust01Button();
        checkExhaust02Button();
        checkExhaust03Button();

    }

    private void OnDisable() {
        globalStats.saveStats();
    }

    public void onShip01ButtonClick() {
        if (stats.coins >= SHIP01_COINS) {
            stats.ship01Unlocked = true;
            stats.coins -= SHIP01_COINS;
            globalStats.saveStats();
            checkShip01Button();
        }
    }

    public void onShip02ButtonClick() {
        if (stats.coins >= SHIP02_COINS) {
            stats.ship02Unlocked = true;
            stats.coins -= SHIP02_COINS;
            globalStats.saveStats();
            checkShip02Button();
        }
    }

    public void onShip03ButtonClick() {
        if (stats.coins >= SHIP03_COINS) {
            stats.ship03Unlocked = true;
            stats.coins -= SHIP03_COINS;
            globalStats.saveStats();
            checkShip03Button();
        }
    }
    public void onBullet01ButtonClick() {
        if (stats.coins >= BULLET01_COINS) {
            stats.bullet01Unlocked = true;
            stats.coins -= BULLET01_COINS;
            globalStats.saveStats();
            checkBullet01Button();
        }
    }

    public void onBullet02ButtonClick() {
        if (stats.coins >= BULLET02_COINS) {
            stats.bullet02Unlocked = true;
            stats.coins -= BULLET02_COINS;
            globalStats.saveStats();
            checkBullet02Button();
        }
    }

    public void onBullet03ButtonClick() {
        if (stats.coins >= BULLET03_COINS) {
            stats.bullet03Unlocked = true;
            stats.coins -= BULLET03_COINS;
            globalStats.saveStats();
            checkBullet03Button();
        }
    }

    public void onExhaust01ButtonClick() {
        if (stats.coins >= EXHAUST01_COINS) {
            stats.exhaust01Unlocked = true;
            stats.coins -= EXHAUST01_COINS;
            globalStats.saveStats();
            checkExhaust01Button();
        }
    }

    public void onExhaust02ButtonClick() {
        if (stats.coins >= EXHAUST02_COINS) {
            stats.exhaust02Unlocked = true;
            stats.coins -= EXHAUST02_COINS;
            globalStats.saveStats();
            checkExhaust02Button();
        }
    }

    public void onExhaust03ButtonClick() {
        if (stats.coins >= EXHAUST03_COINS) {
            stats.exhaust03Unlocked = true;
            stats.coins -= EXHAUST03_COINS;
            globalStats.saveStats();
            checkExhaust03Button();
        }
    }

    public void checkShip01Button() {
        TMPro.TMP_Text buttonText = ship01Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship01Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = SHIP01_COINS.ToString();
        }
    }

    public void checkShip02Button() {
        TMPro.TMP_Text buttonText = ship02Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship02Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = SHIP02_COINS.ToString();
        }
    }

    public void checkShip03Button() {
        TMPro.TMP_Text buttonText = ship03Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship03Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = SHIP03_COINS.ToString();
        }
    }

    public void checkBullet01Button() {
        TMPro.TMP_Text buttonText = bullet01Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet01Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = BULLET01_COINS.ToString();
        }
    }

    public void checkBullet02Button() {
        TMPro.TMP_Text buttonText = bullet02Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet02Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = BULLET02_COINS.ToString();
        }
    }

    public void checkBullet03Button() {
        TMPro.TMP_Text buttonText = bullet03Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet03Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = BULLET03_COINS.ToString();
        }
    }

    public void checkExhaust01Button() {
        TMPro.TMP_Text buttonText = exhaust01Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.exhaust01Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = EXHAUST01_COINS.ToString();
        }
    }

    public void checkExhaust02Button() {
        TMPro.TMP_Text buttonText = exhaust02Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.exhaust02Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = EXHAUST02_COINS.ToString();
        }
    }

    public void checkExhaust03Button() {
        TMPro.TMP_Text buttonText = exhaust03Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.exhaust03Unlocked) {
            buttonText.text = "O";
        } else {
            buttonText.text = EXHAUST03_COINS.ToString();
        }
    }

    public void updateCoinsText() {
        coinsText.text = "Coins: " + stats.coins.ToString();
    }
}
