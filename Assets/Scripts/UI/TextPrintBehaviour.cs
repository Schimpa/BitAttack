using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextPrintBehaviour : MonoBehaviour {

    public TMPro.TMP_Text textElement;

    public UnityEvent onTextPrintFinished;

    [TextArea]
    public string textToPrint;

    [Header("Sound that is played when the text is being typed")]
    public AudioSource dialogSound;

    [Header("Determines how fast a letter is printed")]
    public float letterPrintTime;

    [Header("If this is enabled, the text can be skipped")]
    public bool enableSkipText;

    [SerializeField][Header("Flag, if the print is finished")]
    private bool isFinished;

    private int totalLetterCount;
    private int currentLetterCount;

    private float letterPrintTimer;

    private bool audioSourceAvailable;

    private void OnEnable() {
        resetTextPrint();

        if (dialogSound != null) {
            audioSourceAvailable = true;
        } else {
            audioSourceAvailable = false;
        }

        playAudio();
    }

    private void OnDisable() {
        Cursor.visible = false;
    }

    private void resetTextPrint() {
        textElement.text = "";
        totalLetterCount = textToPrint.Length;
        currentLetterCount = 0;
        letterPrintTimer = 0f;
        isFinished = false;
    }


    void Update() {
        if ( (isFinished == false) && (letterPrintTimer >= letterPrintTime)) {
            printNextLetter();
            letterPrintTimer = 0f;
        } else {
            letterPrintTimer += Time.deltaTime;
        }


        if (enableSkipText && Input.GetButtonDown("Submit")) {
            printFullText();
        }
    }

    void printNextLetter() {
        currentLetterCount++;
        string text = textToPrint.Substring(0, currentLetterCount);

        textElement.text = text;

        if (currentLetterCount >= totalLetterCount) {
            finishText();
        }
    }

    void printFullText() {
        textElement.text = textToPrint;
        finishText();
    }

    private void finishText() {
        isFinished = true;
        Cursor.visible = true;
        stopAudio();
        onTextPrintFinished.Invoke();
    }

    private void playAudio() {
        if (audioSourceAvailable == false) return;
        dialogSound.Play();
    }

    private void stopAudio() {
        if (audioSourceAvailable == false) return;
        dialogSound.Stop();
    }



}
