using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Places a random menu text out of a list of random text each time the main menu is activated!
 */
public class MenuTextBehaviour : MonoBehaviour {

    public TMPro.TMP_Text menuText;

    public List<string> texts;

    void OnEnable() {
        int randomNumber = Random.Range(0, texts.Count);

        menuText.text = texts[randomNumber];
    }

}
