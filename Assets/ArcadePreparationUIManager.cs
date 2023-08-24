using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcadePreparationUIManager : MonoBehaviour {

    public TMPro.TMP_Text spawnIntervalText;
    public TMPro.TMP_Text bitSpeedText;
    public TMPro.TMP_Text spawnIntervalMultiplierText;
    public TMPro.TMP_Text bitSpeedMultiplierText;
    public TMPro.TMP_Text levelDurationText;

    public Slider spawnIntervalSlider;
    public Slider bitSpeedSlider;
    public Slider spawnIntervalMultiplierSlider;
    public Slider bitSpeedMultiplierSlider;
    public Slider levelDurationSlider;

    void Start() {
        onSpawnIntervalSliderValueChange();
        onBitSpeedSliderValueChange();
        onSpawnIntervalMultiplierSliderValueChange();
        onBitSpeedMultiplierSliderValueChange();
        onLevelDurationSliderValueChange();
    }

    public void onSpawnIntervalSliderValueChange() {
        double sliderValue = spawnIntervalSlider.value;
        sliderValue = System.Math.Round(sliderValue, 1);

        spawnIntervalText.text = "Spawn Interval: " + sliderValue.ToString();
    }

    public void onBitSpeedSliderValueChange() {
        double sliderValue = bitSpeedSlider.value;
        sliderValue = System.Math.Round(sliderValue, 1);

        bitSpeedText.text = "Bit Speed: " + sliderValue.ToString();
    }

    public void onSpawnIntervalMultiplierSliderValueChange() {
        double sliderValue = spawnIntervalMultiplierSlider.value;
        sliderValue = System.Math.Round(sliderValue, 1);

        spawnIntervalMultiplierText.text = "Multiplier: " + sliderValue.ToString();
    }

    public void onBitSpeedMultiplierSliderValueChange() {
        double sliderValue = bitSpeedMultiplierSlider.value;
        sliderValue = System.Math.Round(sliderValue, 1);

        bitSpeedMultiplierText.text = "Multiplier: " + sliderValue.ToString();
    }

    public void onLevelDurationSliderValueChange() {
        double sliderValue = levelDurationSlider.value;
        sliderValue = System.Math.Round(sliderValue, 1);

        levelDurationText.text = "Level Duration: " + sliderValue.ToString();
    }

    public void saveValuesInPreferences() {
        int levelDuration = (int)levelDurationSlider.value;

        double spawnInterval = spawnIntervalSlider.value;
        spawnInterval = System.Math.Round(spawnInterval, 1);

        double spawnIntervalMultiplier = spawnIntervalMultiplierSlider.value;
        spawnIntervalMultiplier = System.Math.Round(spawnIntervalMultiplier, 1);

        double bitSpeed = bitSpeedSlider.value;
        bitSpeed = System.Math.Round(bitSpeed, 1);

        double bitSpeedMultiplier = bitSpeedMultiplierSlider.value;
        bitSpeedMultiplier = System.Math.Round(bitSpeedMultiplier, 1);


        PlayerPrefs.SetFloat(ArcadeKeys.SPAWN_INTERVAL.ToString(), (float)spawnInterval);
        PlayerPrefs.SetFloat(ArcadeKeys.SPAWN_INTERVAL_MULTIPLIER.ToString(), (float)spawnIntervalMultiplier);
        PlayerPrefs.SetFloat(ArcadeKeys.BIT_SPEED.ToString(), (float)bitSpeed);
        PlayerPrefs.SetFloat(ArcadeKeys.BIT_SPEED_MULTIPLIER.ToString(), (float)bitSpeedMultiplier);
        PlayerPrefs.SetInt(ArcadeKeys.LEVEL_DURATION.ToString(), levelDuration);
    }

    public void loadArcadeLevel() {
        SceneManager.LoadScene("ArcadeStage");
    }
}
