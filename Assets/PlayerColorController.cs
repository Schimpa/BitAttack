using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorController : MonoBehaviour {

    public Material playerMaterial;

    public ColorMode currentPlayerColor = ColorMode.BLUE;

    public float colorChangeTime;       // The time it takes to change the color of the player 
    private float colorChangeTimer;

    private ColorController colorController;

    void Start() {
        colorController = GameObject.Find("ColorController").GetComponent<ColorController>();
        currentPlayerColor = ColorMode.BLUE;
        setColorBlue();
    }

    // Update is called once per frame
    void Update(){
        colorChangeTimer += Time.deltaTime;
        checkColorChangeTimer();
    }

    private void checkColorChangeTimer() {
        if (colorChangeTimer >= colorChangeTime) {
            colorChangeTimer = 0f;
            updatePlayerColor();
        }
    }

    private void updatePlayerColor() {
        if (currentPlayerColor == ColorMode.BLUE) {
            setColorRed();
        } else if (currentPlayerColor == ColorMode.RED) {
            setColorYellow();
        } else if (currentPlayerColor == ColorMode.YELLOW) {
            setColorBlue();
        }
    }

    public void setColorBlue() {
        colorController.setColorBlue(playerMaterial);
        currentPlayerColor = ColorMode.BLUE;
    }

    public void setColorRed() {
        colorController.setColorRed(playerMaterial);
        currentPlayerColor = ColorMode.RED;
    }

    public void setColorYellow() {
        colorController.setColorYellow(playerMaterial);
        currentPlayerColor = ColorMode.YELLOW;
    }

}
