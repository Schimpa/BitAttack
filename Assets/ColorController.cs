using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {

    public Color colorBlue01;
    public Color colorBlue02;

    public Color colorRed01;
    public Color colorRed02;

    public Color colorYellow01;
    public Color colorYellow02;

    public void setColorBlue(Material mat) {
        mat.SetColor("_Color01", colorBlue01);
        mat.SetColor("_Color02", colorBlue02);
    }
    public void setColorRed(Material mat) {
        mat.SetColor("_Color01", colorRed01);
        mat.SetColor("_Color02", colorRed02);
    }

    public void setColorYellow(Material mat) {
        mat.SetColor("_Color01", colorYellow01);
        mat.SetColor("_Color02", colorYellow02);
    }

}

public enum ColorMode {
    BLUE,
    RED,
    YELLOW
}
