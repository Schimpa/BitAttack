using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour {

    public const int SHIP01_BITS = 0;
    public const int SHIP02_BITS = 100;
    public const int SHIP03_BITS = 200;

    public const int BULLET01_BITS = 0;
    public const int BULLET02_BITS = 100;
    public const int BULLET03_BITS = 200;

    public const int EXHAUST01_BITS = 100;
    public const int EXHAUST02_BITS = 200;
    public const int EXHAUST03_BITS = 400;

    public SoundManager soundManager;

    public GlobalStatsFileManager globalStats;
    public TMPro.TMP_Text bitsText;

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
        updateBitsText();

        checkShip01Button();
        checkShip02Button();
        checkShip03Button();

        checkBullet01Button();
        checkBullet02Button();
        checkBullet03Button();

        checkExhaust01Button();
        checkExhaust02Button();
        checkExhaust03Button();

        setSelectionColor();

    }

    private void OnDisable() {
        globalStats.saveStats();
    }

    private void setSelectionColor() {

        ship01Button.GetComponent<Image>().color = Color.white;
        ship02Button.GetComponent<Image>().color = Color.white;
        ship03Button.GetComponent<Image>().color = Color.white;

        bullet01Button.GetComponent<Image>().color = Color.white;
        bullet02Button.GetComponent<Image>().color = Color.white;
        bullet03Button.GetComponent<Image>().color = Color.white;

        switch (stats.selectedShip) {
            case 0:
                ship01Button.GetComponent<Image>().color = Color.blue;
                break;
            case 1:
                ship02Button.GetComponent<Image>().color = Color.blue;
                break;
            case 2:
                ship03Button.GetComponent<Image>().color = Color.blue;
                break;
        }

        switch (stats.selectedBullet) {
            case 0:
                bullet01Button.GetComponent<Image>().color = Color.blue;
                break;
            case 1:
                bullet02Button.GetComponent<Image>().color = Color.blue;
                break;
            case 2:
                bullet03Button.GetComponent<Image>().color = Color.blue;
                break;
        }
    }

    public void onShip01ButtonClick() {
        if (stats.bits >= SHIP01_BITS && stats.ship01Unlocked == false) {
            stats.ship01Unlocked = true;
            stats.bits -= SHIP01_BITS;
            globalStats.saveStats();
            checkShip01Button();
        }

        if (stats.ship01Unlocked == true) {
            stats.selectedShip = 0;
            soundManager.playSelectionSuccessfullSound();
        } else {
            soundManager.playSelectionFailedSound();
        }
        setSelectionColor();
    }

    public void onShip02ButtonClick() {
        if (stats.bits >= SHIP02_BITS && stats.ship02Unlocked == false) {
            stats.ship02Unlocked = true;
            stats.bits -= SHIP02_BITS;
            globalStats.saveStats();
            checkShip02Button();
        }

        if (stats.ship02Unlocked == true) {
            stats.selectedShip = 1;
            soundManager.playSelectionSuccessfullSound();
        } else {
            soundManager.playSelectionFailedSound();
        }
        setSelectionColor();
    }

    public void onShip03ButtonClick() {
        if (stats.bits >= SHIP03_BITS && stats.ship03Unlocked == false) {
            stats.ship03Unlocked = true;
            stats.bits -= SHIP03_BITS;
            globalStats.saveStats();
            checkShip03Button();
        }

        if (stats.ship03Unlocked == true) {
            stats.selectedShip = 2;
            soundManager.playSelectionSuccessfullSound();
        } else {
            soundManager.playSelectionFailedSound();
        }
        setSelectionColor();
    }
    public void onBullet01ButtonClick() {
        if (stats.bits >= BULLET01_BITS) {
            stats.bullet01Unlocked = true;
            stats.bits -= BULLET01_BITS;
            globalStats.saveStats();
            checkBullet01Button();
        }

        if (stats.bullet01Unlocked == true) {
            stats.selectedBullet = 0;
            soundManager.playSelectionSuccessfullSound();
        } else {
            soundManager.playSelectionFailedSound();
        }
        setSelectionColor();
    }

    public void onBullet02ButtonClick() {
        if (stats.bits >= BULLET02_BITS) {
            stats.bullet02Unlocked = true;
            stats.bits -= BULLET02_BITS;
            globalStats.saveStats();
            checkBullet02Button();
        }

        if (stats.bullet02Unlocked == true) {
            stats.selectedBullet = 1;
            soundManager.playSelectionSuccessfullSound();
        } else {
            soundManager.playSelectionFailedSound();
        }
        setSelectionColor();
    }

    public void onBullet03ButtonClick() {
        if (stats.bits >= BULLET03_BITS) {
            stats.bullet03Unlocked = true;
            stats.bits -= BULLET03_BITS;
            globalStats.saveStats();
            checkBullet03Button();
        }

        if (stats.bullet03Unlocked == true) {
            stats.selectedBullet = 2;
            soundManager.playSelectionSuccessfullSound();
        } else {
            soundManager.playSelectionFailedSound();
        }
        setSelectionColor();
    }

    public void onExhaust01ButtonClick() {
        if (stats.bits >= EXHAUST01_BITS) {
            stats.exhaust01Unlocked = true;
            stats.bits -= EXHAUST01_BITS;
            globalStats.saveStats();
            checkExhaust01Button();
        }
    }

    public void onExhaust02ButtonClick() {
        if (stats.bits >= EXHAUST02_BITS) {
            stats.exhaust02Unlocked = true;
            stats.bits -= EXHAUST02_BITS;
            globalStats.saveStats();
            checkExhaust02Button();
        }
    }

    public void onExhaust03ButtonClick() {
        if (stats.bits >= EXHAUST03_BITS) {
            stats.exhaust03Unlocked = true;
            stats.bits -= EXHAUST03_BITS;
            globalStats.saveStats();
            checkExhaust03Button();
        }
    }

    public void checkShip01Button() {
        TMPro.TMP_Text buttonText = ship01Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship01Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = SHIP01_BITS.ToString();
        }
    }

    public void checkShip02Button() {
        TMPro.TMP_Text buttonText = ship02Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship02Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = SHIP02_BITS.ToString();
        }
    }

    public void checkShip03Button() {
        TMPro.TMP_Text buttonText = ship03Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship03Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = SHIP03_BITS.ToString();
        }
    }

    public void checkBullet01Button() {
        TMPro.TMP_Text buttonText = bullet01Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet01Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = BULLET01_BITS.ToString();
        }
    }

    public void checkBullet02Button() {
        TMPro.TMP_Text buttonText = bullet02Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet02Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = BULLET02_BITS.ToString();
        }
    }

    public void checkBullet03Button() {
        TMPro.TMP_Text buttonText = bullet03Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet03Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = BULLET03_BITS.ToString();
        }
    }

    public void checkExhaust01Button() {
        TMPro.TMP_Text buttonText = exhaust01Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.exhaust01Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = EXHAUST01_BITS.ToString();
        }
    }

    public void checkExhaust02Button() {
        TMPro.TMP_Text buttonText = exhaust02Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.exhaust02Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = EXHAUST02_BITS.ToString();
        }
    }

    public void checkExhaust03Button() {
        TMPro.TMP_Text buttonText = exhaust03Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.exhaust03Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = EXHAUST03_BITS.ToString();
        }
    }

    public void updateBitsText() {
        bitsText.text = "Bits: " + stats.bits.ToString();
    }

}
