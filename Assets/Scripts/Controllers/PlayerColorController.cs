using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorController : MonoBehaviour {

    public Material playerMaterial;

    public ColorMode currentPlayerColor = ColorMode.BLUE;
  
    [Header("Shall the color be changed by time?. If this is disabled, the player color has to be changes manually," +
        "for example by the obstacles or bullets")]
    public bool changeColorByTime;
    public float colorChangeTime;       // The time it takes to change the color of the player 
    
    [Header("Has to be in order BLUE, GREEN, PURPLE")]
    public List<GameObject> trails;

    private float colorChangeTimer;

    private ColorController colorController;

    void Start() {
        colorController = GameObject.Find("ColorController").GetComponent<ColorController>();
        currentPlayerColor = ColorMode.BLUE;
        setColorBlue();
    }

    // Update is called once per frame
    void Update(){
        if (changeColorByTime == true) {
            colorChangeTimer += Time.deltaTime;
            checkColorChangeTimer();
        }
    }

    private void checkColorChangeTimer() {
        if (colorChangeTimer >= colorChangeTime) {
            colorChangeTimer = 0f;
            changePlayerColor();
        }
    }

    public void changePlayerColor() {
        if (currentPlayerColor == ColorMode.BLUE) {
            setColorRed();
        } else if (currentPlayerColor == ColorMode.GREEN) {
            setColorYellow();
        } else if (currentPlayerColor == ColorMode.PURPLE) {
            setColorBlue();
        }
    }

    public void setColorBlue() {
        colorController.setColorBlue(playerMaterial);
        currentPlayerColor = ColorMode.BLUE;

        trails[0].SetActive(true);  // BLUE
        trails[1].SetActive(false);  // RED
        trails[2].SetActive(false);  // GREEN
    }

    public void setColorRed() {
        colorController.setColoGreend(playerMaterial);
        currentPlayerColor = ColorMode.GREEN;

        trails[0].SetActive(false);  // BLUE
        trails[1].SetActive(true);  // RED
        trails[2].SetActive(false);  // GREEN
    }

    public void setColorYellow() {
        colorController.setColorPurple(playerMaterial);
        currentPlayerColor = ColorMode.PURPLE;

        trails[0].SetActive(false);  // BLUE
        trails[1].SetActive(false);  // RED
        trails[2].SetActive(true);  // GREEN
    }

}
