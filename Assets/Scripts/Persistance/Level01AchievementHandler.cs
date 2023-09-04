using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level01AchievementHandler : AchievementHandler {

    public override void initAchievements() {
        this.achievementCount = 6;
        this.achievements = new List<bool>();
        for (int i = 0; i < 6; i++) {
            this.achievements.Add(false);
        }
    }

    /**
     * Validates achievement conditions
     * Returns true if one or more achievments are unlocked (false -> true)
     */
    public override void validateAchievements(StageStats stageStats) {
        if (stageStats.topLevelReached >= 10 && this.achievements[0] == false) {
            this.achievements[0] = true;
        }

        if (stageStats.topLevelReached >= 15 && this.achievements[1] == false) {
            this.achievements[1] = true;
        }

        if (stageStats.topLevelReached >= 20 && this.achievements[2] == false) {
            this.achievements[2] = true;
        }

        if (stageStats.topBitsCollected >= 25 && this.achievements[3] == false) {
            this.achievements[3] = true;
        }

        if (stageStats.topBitsCollected >= 50 && this.achievements[4] == false) {
            this.achievements[4] = true;
        }

        if (stageStats.totalObstaclesAvoided >= 3000 && this.achievements[5] == false) {
            this.achievements[5] = true;
        }
    }

    public override bool checkIfNewAchievementUnlocked(StageStats stageStats) {
        if (stageStats.topLevelReached >= 10 && this.achievements[0] == false) {
            return true;
        }

        if (stageStats.topLevelReached >= 15 && this.achievements[1] == false) {
            return true;
        }

        if (stageStats.topLevelReached >= 20 && this.achievements[2] == false) {
            return true;
        }

        if (stageStats.topBitsCollected >= 25 && this.achievements[3] == false) {
            return true;
        }

        if (stageStats.topBitsCollected >= 50 && this.achievements[4] == false) {
            return true;
        }

        if (stageStats.totalObstaclesAvoided >= 3000 && this.achievements[5] == false) {
            return true;
        }
        return false;
    }

}
