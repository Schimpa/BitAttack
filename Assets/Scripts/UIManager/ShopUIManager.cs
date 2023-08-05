using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour {

    [Header("The price in bits of the items")]
    public int ship01Price;
    public int ship02Price;
    public int ship03Price;

    public int bullet01Price;
    public int bullet02Price;
    public int bullet03Price;

    [Header("The names of the items")]
    public string ship01Name;
    public string ship02Name;
    public string ship03Name;

    public string bullet01Name;
    public string bullet02Name;
    public string bullet03Name;

    [Header("The description of the items")]
    [Multiline]public string ship01Description;
    [Multiline] public string ship02Description;
    [Multiline] public string ship03Description;

    [Multiline] public string bullet01Description;
    [Multiline] public string bullet02Description;
    [Multiline] public string bullet03Description;

    public SoundManager soundManager;

    public GlobalStatsFileManager globalStats;
    public TMPro.TMP_Text bitsText;

    public GameObject ship01Button;
    public GameObject ship02Button;
    public GameObject ship03Button;

    public GameObject bullet01Button;
    public GameObject bullet02Button;
    public GameObject bullet03Button;

    public TMPro.TMP_Text itemNameText;
    public TMPro.TMP_Text itemDescriptionText;

    private GlobalStats stats;

    void OnEnable() {
        globalStats.loadStats();
        stats = globalStats.getGlobalStats();
        updateBitsText();
        itemNameText.text = "";
        itemDescriptionText.text = "";

        checkShip01Button();
        checkShip02Button();
        checkShip03Button();

        checkBullet01Button();
        checkBullet02Button();
        checkBullet03Button();

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
        if (stats.bits >= ship01Price && stats.ship01Unlocked == false) {
            stats.ship01Unlocked = true;
            stats.bits -= ship01Price;
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
        updateBitsText();
    }

    public void onShip02ButtonClick() {
        if (stats.bits >= ship02Price && stats.ship02Unlocked == false) {
            stats.ship02Unlocked = true;
            stats.bits -= ship02Price;
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
        updateBitsText();
    }

    public void onShip03ButtonClick() {
        if (stats.bits >= ship03Price && stats.ship03Unlocked == false) {
            stats.ship03Unlocked = true;
            stats.bits -= ship03Price;
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
        updateBitsText();
    }
    public void onBullet01ButtonClick() {
        if (stats.bits >= bullet01Price && stats.bullet01Unlocked == false) {
            stats.bullet01Unlocked = true;
            stats.bits -= bullet01Price;
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
        updateBitsText();
    }

    public void onBullet02ButtonClick() {
        if (stats.bits >= bullet02Price && stats.bullet02Unlocked == false) {
            stats.bullet02Unlocked = true;
            stats.bits -= bullet02Price;
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
        updateBitsText();
    }

    public void onBullet03ButtonClick() {
        if (stats.bits >= bullet03Price && stats.bullet03Unlocked == false) {
            stats.bullet03Unlocked = true;
            stats.bits -= bullet03Price;
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
        updateBitsText();
    }
    public void checkShip01Button() {
        TMPro.TMP_Text buttonText = ship01Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship01Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = ship01Price.ToString();
        }
    }

    public void checkShip02Button() {
        TMPro.TMP_Text buttonText = ship02Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship02Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = ship02Price.ToString();
        }
    }

    public void checkShip03Button() {
        TMPro.TMP_Text buttonText = ship03Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.ship03Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = ship03Price.ToString();
        }
    }

    public void checkBullet01Button() {
        TMPro.TMP_Text buttonText = bullet01Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet01Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = bullet01Price.ToString();
        }
    }

    public void checkBullet02Button() {
        TMPro.TMP_Text buttonText = bullet02Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet02Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = bullet02Price.ToString();
        }
    }

    public void checkBullet03Button() {
        TMPro.TMP_Text buttonText = bullet03Button.GetComponentInChildren<TMPro.TMP_Text>();
        if (stats.bullet03Unlocked) {
            buttonText.text = "";
        } else {
            buttonText.text = bullet03Price.ToString();
        }
    }

    public void onShip01Hover() {
        itemNameText.text = ship01Name;
        itemDescriptionText.text = ship01Description;
    }

    public void onShip02Hover() {
        itemNameText.text = ship02Name;
        itemDescriptionText.text = ship02Description;
    }

    public void onShip03Hover() {
        itemNameText.text = ship03Name;
        itemDescriptionText.text = ship03Description;
    }

    public void onBullet01Hover() {
        itemNameText.text = bullet01Name;
        itemDescriptionText.text = bullet01Description;
    }

    public void onBullet02Hover() {
        itemNameText.text = bullet02Name;
        itemDescriptionText.text = bullet02Description;
    }

    public void onBullet03Hover() {
        itemNameText.text = bullet03Name;
        itemDescriptionText.text = bullet03Description;
    }


    public void updateBitsText() {
        bitsText.text = "Bits: " + stats.bits.ToString();
    }

}
