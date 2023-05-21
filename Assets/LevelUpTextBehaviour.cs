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
}
