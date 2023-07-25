using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGameUIManager : GameUIManagerBase {

    public Animation levelUpTextAnimation;
    public LevelUpTextBehaviour levelUpText;

    protected override void OnEnable() {
        base.OnEnable();
    }

    public override void updateUIProperties(int score) {
        base.updateUIProperties(score);
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
