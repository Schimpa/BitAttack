using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/**
 * This class is responsible for saving and loading the total stats of the stage
 */
public class TotalStageStatsFileManager : MonoBehaviour {

    public string stageStatsFileName;

    private BinaryFormatter formatter;
    private string filePath;

    private StageStats stageStats;

    void Start() {
        formatter = new BinaryFormatter();
        filePath = Application.persistentDataPath + "/" + stageStatsFileName + ".stats";
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

            stageStats = formatter.Deserialize(stream) as StageStats;
            stream.Close();
        } else {
            // No File avaiable, create new StageStats instance
            stageStats = new StageStats();
        }

    }

    public void resetStats() {
        File.Delete(filePath);
    }

    public StageStats getStageStats() {
        return this.stageStats;
    }
}
