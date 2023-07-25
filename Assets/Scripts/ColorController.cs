using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {

    public Color colorBlue01;
    public Color colorBlue02;

    public Color colorGreen01;
    public Color colorGreen02;

    public Color colorPurple01;
    public Color colorPurple02;

    public void setColorBlue(Material mat) {
        mat.SetColor("_Color01", colorBlue01);
        mat.SetColor("_Color02", colorBlue02);
    }
    public void setColorRed(Material mat) {
        mat.SetColor("_Color01", colorGreen01);
        mat.SetColor("_Color02", colorGreen02);
    }

    public void setColorYellow(Material mat) {
        mat.SetColor("_Color01", colorPurple01);
        mat.SetColor("_Color02", colorPurple02);
    }

}

public enum ColorMode {
    BLUE,
    GREEN,
    PURPLE
}
