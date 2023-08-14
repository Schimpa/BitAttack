using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlackScreenFadeBehaviour : MonoBehaviour {

    public SpriteRenderer backgroundSprite;

    [Header("Duration of the fade in/out in seconds")]
    public float fadeDuration;

    [Header("Shall the fade in happen on Game Start")]
    public bool fadeOnStart;

    [Header("What shall happen when the fade in/out finished?")]
    public UnityEvent onFadeFinished;

    [SerializeField][Header("Is it Fade in or Fade out")]
    private FadeState currentFadeState;

    private bool isFadeBeingInProgress;
    private float fadeProgressTimer;

    private void OnEnable() {
        isFadeBeingInProgress = false;
        fadeProgressTimer = 0;
    }

    void Start() {
        if (fadeOnStart) {
            isFadeBeingInProgress = true;
        }
    }


    void Update() {
        if (isFadeBeingInProgress) {
            fadeProgressTimer += Time.deltaTime;
            setBackgroundColor();
        }       
    }

    public void fadeIn() {
        isFadeBeingInProgress = true;
        fadeProgressTimer = 0;
        currentFadeState = FadeState.FADE_IN;
    }

    public void fadeOut() {
        isFadeBeingInProgress = true;
        fadeProgressTimer = 0;
        currentFadeState = FadeState.FADE_OUT;
    }

    private void finishFade() {
        isFadeBeingInProgress = false;
        onFadeFinished.Invoke();
    }

    private void setBackgroundColor() {
        float backgroundAlpha = 0f;
        if (currentFadeState == FadeState.FADE_IN) { // From Black to Transparent
            backgroundAlpha = 1 - (fadeProgressTimer / fadeDuration);
            if (backgroundAlpha <= 0) { backgroundAlpha = 0; finishFade(); }

        } else if (currentFadeState == FadeState.FADE_OUT) {  // From Transparent to Black
            backgroundAlpha = fadeProgressTimer / fadeDuration;
            if (backgroundAlpha >= 1) { backgroundAlpha = 1; finishFade(); }

        }

        backgroundSprite.color = new Color(0, 0, 0, backgroundAlpha);
    }
}

enum FadeState {
    FADE_IN,    // From Black to Transparent
    FADE_OUT    // From Transparent to Black
}
