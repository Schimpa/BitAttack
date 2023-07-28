using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigurator : MonoBehaviour {

    public GameMode gameMode;

    [Header("To rotate the camera by 90°")]
    public Camera mainCamera;

    [Header("Set the correct input (up/down or left/right) based on game mode and camera rotation")]
    public MovementController movementController;

    [Header("The spawner is moved to be outside of the camera field")]
    public GameObject spawner;

    [Header("The player spawn position is moved to be in the bottom / left 15% of the screen")]
    public GameObject playerSpawnPosition;

    [Header("The particle emmiters will be placed just outside the camera view, same as the spawner")]
    public GameObject backgroundCubes;
    public GameObject backgroundLasers;
    public GameObject backgroundPixels;

    void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;

        movementController.setGameMode(this.gameMode);

        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float backgroundShapeSpawnerWidth = 0f;
        float viewBorder = 0f;

        if (gameMode == GameMode.PC) {
            mainCamera.transform.Rotate(new Vector3(0, 0, 90));
            backgroundShapeSpawnerWidth = Mathf.Abs(stageDimensions.y) * 2;
            viewBorder = Mathf.Abs(stageDimensions.x);
        } else {
            backgroundShapeSpawnerWidth = Mathf.Abs(stageDimensions.x) * 2;
            viewBorder = Mathf.Abs(stageDimensions.y);
        }

        
        ParticleSystem.ShapeModule backgroundCubesShape = backgroundCubes.GetComponent<ParticleSystem>().shape;
        backgroundCubesShape.scale = new Vector3(backgroundShapeSpawnerWidth, 1, 1);

        ParticleSystem.ShapeModule backgroundLasersShape = backgroundLasers.GetComponent<ParticleSystem>().shape;
        backgroundLasersShape.scale = new Vector3(backgroundShapeSpawnerWidth, 1, 1);

        ParticleSystem.ShapeModule backgroundPixelsShape = backgroundPixels.GetComponent<ParticleSystem>().shape;
        backgroundPixelsShape.scale = new Vector3(backgroundShapeSpawnerWidth, 1, 1);


        backgroundCubes.SetActive(true);
        backgroundLasers.SetActive(true);
        backgroundPixels.SetActive(true);

        spawner.transform.position = new Vector3(
            spawner.transform.position.x, viewBorder + 2, spawner.transform.position.z);

        backgroundCubes.transform.position = new Vector3(
            backgroundCubes.transform.position.x, viewBorder + 5, backgroundCubes.transform.position.z);

        backgroundLasers.transform.position = new Vector3(
            backgroundLasers.transform.position.x, viewBorder + 5, backgroundLasers.transform.position.z);

        backgroundPixels.transform.position = new Vector3(
            backgroundPixels.transform.position.x, viewBorder + 5, backgroundPixels.transform.position.z);


        float playerSpawnPosY = -Mathf.Abs(stageDimensions.y) + ( Mathf.Abs(stageDimensions.y) * 0.2f);

        playerSpawnPosition.transform.position = new Vector3(
            playerSpawnPosition.transform.position.x,playerSpawnPosY,playerSpawnPosition.transform.position.z);

    }

    void Update() {
        
    }


}

[System.Serializable]
public enum GameMode {
    PC,
    MOBILE
}
