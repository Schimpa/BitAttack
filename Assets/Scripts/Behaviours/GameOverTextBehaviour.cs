using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTextBehaviour : MonoBehaviour {

    public List<string> badMotivations;
    public List<string> normalMotivations;
    public List<string> goodMotivations;

    public int badMotivationLevelThreshold;
    public int normalMotivationLevelThreshold;
    public int goodMotivationLevelThreshold;

    public TMPro.TMP_Text motivationText;

    public TMPro.TMP_Text infoText;

    void Start() {
        checkMotivationThresholdLevel();
    }


    void Update() {
        
    }

    public void createMotivationTextByLevel(int level) {
        if (level >= goodMotivationLevelThreshold) {
            motivationText.text = goodMotivations[Random.Range(0, goodMotivations.Count)];
        } else if (level >= normalMotivationLevelThreshold) {
            motivationText.text = normalMotivations[Random.Range(0, normalMotivations.Count)];
        } else {
            motivationText.text = badMotivations[Random.Range(0, badMotivations.Count)];
        }
    }

    public void setCustomMotivationText(string text) {
        motivationText.text = text;
    }

    public void setCustomInfoText(string text) {
        infoText.text = text;
    }

    void checkMotivationThresholdLevel() {
        if (badMotivationLevelThreshold > normalMotivationLevelThreshold) {
            Debug.LogError("The level for bad motivation must be lower than for normal motivation!");
            badMotivationLevelThreshold = normalMotivationLevelThreshold - 1;
        }
        if (normalMotivationLevelThreshold > goodMotivationLevelThreshold) {
            Debug.LogError("The level for bad motivation must be lower than for normal motivation!");
            goodMotivationLevelThreshold = normalMotivationLevelThreshold - 1;
        }
    }
}
