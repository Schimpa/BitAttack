using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Script to switch between multiple UI contents. Only one content is shown at a time
 * For example: Achievements - Stats - Texts
 * Switchable by buttons
 */
public class ScreenContentSwitch : MonoBehaviour {

    public List<GameObject> contentList;

    private int currentSelection;
    private int contentListSize;

    void Start() {
        currentSelection = 0;
        contentListSize = contentList.Count;
    }

    public void goToNextContent() {
        disableAllContents();

        currentSelection++;

        if (currentSelection >= contentListSize) {
            currentSelection = 0;
        }

        contentList[currentSelection].SetActive(true);
    }

    public void goToPreviousContent() {
        disableAllContents();

        currentSelection--;

        if (currentSelection < 0) {
            currentSelection = contentListSize -1;
        }

        contentList[currentSelection].SetActive(true);
    }

    private void disableAllContents() {
        foreach (GameObject obj in contentList) {
            obj.SetActive(false);
        }
    }

}
