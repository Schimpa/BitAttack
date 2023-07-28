using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGameUIManager : GameUIManagerBase {

    public Animation levelUpTextAnimation;
    public LevelUpTextBehaviour levelUpText;
    public TMPro.TMP_Text bitsText;

    protected override void OnEnable() {
        base.OnEnable();
    }

    public void updateUIProperties(int score, int bits) {
        base.updateUIProperties(score);
        bitsText.text = bits.ToString();
    }

    public override void resetUI() {
        base.resetUI();
        levelUpTextAnimation.Stop();
        levelUpTextAnimation.Rewind();
    }

    public void playLevelUpAnimation(int level) {
        levelUpText.playLevelUpAnimation(level);
    }

    public void playLevelUpEmptyAnimation() {
        levelUpText.playEmptyAnimation();
    }

}
