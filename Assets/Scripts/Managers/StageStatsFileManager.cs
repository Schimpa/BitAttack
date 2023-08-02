using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/**
 * This class is responsible for saving and loading the total stats of the stage
 */
public class StageStatsFileManager : MonoBehaviour {

    public string stageStatsFileName;

    private BinaryFormatter formatter;
    private string filePath;

    private StageStats stageStats;

    private bool newAchievementUnlocked;

    void Awake() {
        formatter = new BinaryFormatter();
        newAchievementUnlocked = false;
        if (stageStatsFileName != "") {
            filePath = Application.persistentDataPath + "/" + stageStatsFileName + ".stats";
        }
    }

    public void saveStats() {
        FileStream stream = new FileStream(this.filePath, FileMode.Create);

        formatter.Serialize(stream, stageStats);
        stream.Close();

    }

    public void loadStats() {
        if (File.Exists(this.filePath)) {
            // Load existing data
            FileStream stream = new FileStream(this.filePath, FileMode.Open);
            if (stream.Length == 0) {
                stageStats = new StageStats();
            }
            else {
                stageStats = formatter.Deserialize(stream) as StageStats;
            }
            stream.Close();
        } else {
            // No File avaiable, create new StageStats instance
            stageStats = new StageStats();
        }

    }

    public void resetStats() {
        File.Delete(filePath);
        stageStats = new StageStats();
    }

    public StageStats getStageStats() {
        return this.stageStats;
    }

    public void updateStatsFileName(string stageStatsFileName) {
        this.stageStatsFileName = stageStatsFileName;

        this.filePath = Application.persistentDataPath + "/" + stageStatsFileName + ".stats";
    }

    public void validateStage01Achievements() {
        if (stageStats.topLevelReached >= 10 && stageStats.achievement01Reached == false) {
            stageStats.achievement01Reached = true;
            this.newAchievementUnlocked = true;
        }

        if (stageStats.totalObstaclesAvoided >= 1000 && stageStats.achievement02Reached == false) {
            stageStats.achievement02Reached = true;
            this.newAchievementUnlocked = true;
        }
        
        if (stageStats.topBitsCollected >= 20 && stageStats.achievement03Reached == false) {
            stageStats.achievement03Reached = true;
            this.newAchievementUnlocked = true;
        }

    }

    public bool isNewAchievementUnlocked() {
        return this.newAchievementUnlocked;
    }

    public void setNewAchievementUnlocked(bool value) {
        this.newAchievementUnlocked = false;
    }
}
