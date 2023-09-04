using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/**
 * This class is responsible for saving and loading the total stats of the stage
 */
public class StageStatsFileManager : MonoBehaviour {

    public string stageStatsFileName;

    [Header("Handles achievmenet validation for each stage")]
    public AchievementHandler achievementHandler;

    private BinaryFormatter formatter;
    private string filePath;

    private StageStats stageStats;

    private bool newAchievementUnlocked;

    void OnEnable() {
        newAchievementUnlocked = false;
        formatter = new BinaryFormatter();
        if (stageStatsFileName != "") { 
            filePath = Application.persistentDataPath + "/" + stageStatsFileName + ".stats";
            loadStats();
        }
    }

    public void saveStats() {
        FileStream stream = new FileStream(this.filePath, FileMode.Create);

        formatter.Serialize(stream, stageStats);
        stream.Close();

    }

    public void loadStats() {
        achievementHandler.initAchievements();

        if (File.Exists(this.filePath)) {
            // Load existing data
            FileStream stream = new FileStream(this.filePath, FileMode.Open);
            if (stream.Length == 0) {
                stageStats = new StageStats();
            }
            else {
                stageStats = formatter.Deserialize(stream) as StageStats;

                // To set the achievements            
                achievementHandler.validateAchievements(stageStats);

            }
            stream.Close();
        } else {
            // No File avaiable, create new StageStats instance
            stageStats = new StageStats();
        }

    }

    public void resetStats() {
        File.Delete(filePath);
        loadStats();
    }

    public StageStats getStageStats() {
        return this.stageStats;
    }

    public void updateStatsFileName(string stageStatsFileName) {
        this.stageStatsFileName = stageStatsFileName;

        this.filePath = Application.persistentDataPath + "/" + stageStatsFileName + ".stats";
    }

    public void checkIfNewAchievementUnlocked() {
        newAchievementUnlocked = achievementHandler.checkIfNewAchievementUnlocked(stageStats);
    }

    public bool isNewAchievementUnlocked() {
        return this.newAchievementUnlocked;
    }
}
