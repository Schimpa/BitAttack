using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AchievementHandler : MonoBehaviour {

    protected List<bool> achievements;
    protected int achievementCount;

    //Instantiates the list of achievements, depending on how many achievements are there
    public abstract void initAchievements();
    public abstract void validateAchievements(StageStats stageStats);
    public abstract bool checkIfNewAchievementUnlocked(StageStats stageStats);

    public List<bool> getAchievements() {
        return this.achievements;
    }
}
