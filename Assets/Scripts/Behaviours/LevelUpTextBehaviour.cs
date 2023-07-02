using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpTextBehaviour : MonoBehaviour {

    public Animation anim;
    public TMPro.TMP_Text levelUpText;

    public void playLevelUpAnimation(int level) {
        levelUpText.text = level.ToString();
        anim.Play();
    }

    public void playEmptyAnimation() {
        /**
         * This is a trick that is used to reset the animation, when a new game after a game over starts
         * This way, the animation is not freezed in the middle when a new game starts, and the level up text disappears.
         */

        levelUpText.text = "";
        anim.Play();
    }
}
