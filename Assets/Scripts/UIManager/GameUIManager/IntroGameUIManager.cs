using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Game UI Manager used in the intro level
 */
public class IntroGameUIManager : GameUIManagerBase {

    public TMPro.TMP_Text objectiveText;
    public List<TextPopUpBehaviour> textPopUps;

    public int totalBitsAmount; // Total bits needed to win

    protected override void OnEnable() {
        base.OnEnable();
    }

    public void updateUIProperties(int score, int bitsCollected) {
        base.updateUIProperties(score);
        string objectiveString = 
            "BITS: " + bitsCollected.ToString() + "/" + totalBitsAmount.ToString();
        objectiveText.text = objectiveString;
    }

    public override void resetUI() {
        base.resetUI();
        objectiveText.text = "";
        foreach (TextPopUpBehaviour textPopUp in textPopUps) {
            textPopUp.gameObject.SetActive(true);
            textPopUp.resetTimer();
        }
    }

}
