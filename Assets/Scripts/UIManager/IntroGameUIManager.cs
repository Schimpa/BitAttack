using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Game UI Manager used in the intro level
 */
public class IntroGameUIManager : MonoBehaviour {

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text objectiveText;

    public List<TextPopUpBehaviour> textPopUps;

    public int totalBitsAmount;

    public void OnEnable() {
        resetUI();
    }

    public void updateUIProperties(int score, int bitsCollected) {
        scoreText.text = score.ToString();
        string objectiveString = "Bits collected: " + bitsCollected.ToString() + "/" + totalBitsAmount.ToString();

        objectiveText.text = objectiveString;

    }

    public void resetUI() {
        scoreText.text = "0";
        
        foreach (TextPopUpBehaviour textPopUp in textPopUps) {
            textPopUp.gameObject.SetActive(true);
            textPopUp.resetTimer();
        }
    }

}
