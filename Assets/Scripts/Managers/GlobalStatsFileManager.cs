using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/**
 * This class is responsible for saving and loading the global stats of the game
 * Like coin amount and unlocked items
 */
public class GlobalStatsFileManager : MonoBehaviour {

    public const string GLOBAL_STATS_FILE_NAME = "GlobalStats";

    private BinaryFormatter formatter;
    private string filePath;

    private GlobalStats globalStats;

    void Awake() {
        formatter = new BinaryFormatter();
        filePath = Application.persistentDataPath + "/" + GLOBAL_STATS_FILE_NAME + ".stats";
    }

    public void saveStats() {
        FileStream stream = new FileStream(this.filePath, FileMode.Create);

        formatter.Serialize(stream, globalStats);
        stream.Close();

    }

    public void loadStats() {
        if (File.Exists(this.filePath)) {
            // Load existing data
            FileStream stream = new FileStream(this.filePath, FileMode.Open);
            if (stream.Length == 0) {
                // File is empty, create new instance of GlobalStats
                globalStats = new GlobalStats();
            } else {
                globalStats = formatter.Deserialize(stream) as GlobalStats;
            }    
            stream.Close();
        } else {
            // No File avaiable, create new GlobalStats instance
            globalStats = new GlobalStats();
        }

    }

    public void resetStats() {
        File.Delete(filePath);
        globalStats = new GlobalStats();
    }

    public GlobalStats getGlobalStats() {
        return this.globalStats;
    }

}
