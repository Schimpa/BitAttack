using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopUpBehaviour : MonoBehaviour {

    public float delay; // The delay in seconds, after which the pop up will appear

    private Transform[] childTransforms;
    private float timer;

    void Start() {
        childTransforms = this.gameObject.GetComponentsInChildren<Transform>();
        timer = 0f;
        if (delay > 0f) {
            disableAllChildGameObjects();
        } else {
            Time.timeScale = 0f;
        }
        
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if (timer >= delay) {
            enableAllChildGameObjects();
            Time.timeScale = 0f;
        }
    }

    private void disableAllChildGameObjects() {
        foreach(Transform obj in childTransforms) {
            obj.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(true);
    }

    private void enableAllChildGameObjects() {
        foreach (Transform obj in childTransforms) {
            obj.gameObject.SetActive(true);
        }
    }

    public void finishPopUp() {
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
