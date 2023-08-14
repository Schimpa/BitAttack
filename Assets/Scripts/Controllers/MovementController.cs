using UnityEngine;

public class MovementController : MonoBehaviour {

    [Header("Set the correct input (up/down or left/right) based on game mode and camera rotation")]
    public GameMode gameMode;

    public float moveSpeedXAxis;
    public float moveSpeedYAxis;
    public float joystickSensitivity;

    public float objectMovementRotation;

    public GameObject objectToMove;

    [Header("To calculate the movement border")]
    public ObstacleSpawner spawner;

    // The maximum value, in which the character can move on the play field (Both directions)
    private float xAxisMovementBorder;

    private float yAxisMovementBorderMin;
    private float yAxisMovementBorderMax;

    private void Start() {
        loadPreferences();
    }

    void Update() { 
        if (objectToMove == null) return;

        Vector2 axisInput = getInput();
        Vector2 pos = objectToMove.transform.position;

        validateMovementConditionsBasedOnInput(axisInput, pos);

        updateObjectRotation(-axisInput);
    }

    private Vector2 getInput() {
        float xAxisInput = 0f;
        float yAxisInput = 0f;

        if (gameMode == GameMode.MOBILE) {   
            // The input from left and right arrow is taken
            xAxisInput = Input.GetAxis("Horizontal");
        } else if (gameMode == GameMode.PC) {
            // The camera is rotated by 90°, so the vertical input from up/down arrow is taken
            xAxisInput = -Input.GetAxis("Vertical");
            yAxisInput = Input.GetAxis("Horizontal");
        }

        return new Vector2(xAxisInput,yAxisInput);
    }

    private void validateMovementConditionsBasedOnInput(Vector2 axisInput, Vector2 pos) {
        validateMovementConditionsOnXAxis(axisInput, pos);
        validateMovementConditionsOnYAxis(axisInput, pos);
    }

    private void validateMovementConditionsOnXAxis(Vector2 axisInput, Vector2 pos) {
        if (Mathf.Abs(pos.x) > xAxisMovementBorder) {
            if ((pos.x < -xAxisMovementBorder) && axisInput.x > 0) {
                // Allow player to move from left (outside border) to the right back into the area
                updateObjectPosition(axisInput * new Vector2(1, 0) * moveSpeedXAxis);
            } else if ((pos.x > xAxisMovementBorder) && axisInput.x < 0) {
                // Allow player to move from right (outside border) to the left back into the area
                updateObjectPosition(axisInput * new Vector2(1, 0) * moveSpeedXAxis);
            }
        } else {
            updateObjectPosition(axisInput * new Vector2(1, 0) * moveSpeedXAxis);
        }
    }

    private void validateMovementConditionsOnYAxis(Vector2 axisInput, Vector2 pos) {
        if (pos.y < yAxisMovementBorderMin) {
            if ((pos.y < -xAxisMovementBorder) && axisInput.y > 0) {
                // Allow player to move from bottom (outside border) up back into the area
                updateObjectPosition(axisInput * new Vector2(0, 1) * moveSpeedYAxis);
            }
        } else if (pos.y > yAxisMovementBorderMax) {
            if ((pos.y > yAxisMovementBorderMax) && axisInput.y < 0) {
                // Allow player to move from bottom (outside border) up back into the area
                updateObjectPosition(axisInput * new Vector2(0, 1) * moveSpeedYAxis);
            }
        } else {
            updateObjectPosition(axisInput * new Vector2(0, 1) * moveSpeedYAxis);
        }
    }



    private void updateObjectPosition(Vector2 axisInput) {
        Vector3 moveVector = axisInput  * Time.deltaTime * 10;

        objectToMove.transform.Translate(moveVector);
        objectToMove.transform.position = new Vector3(
            objectToMove.transform.position.x, 
            objectToMove.transform.position.y, 
            0
        );
    }

    private void updateObjectRotation(Vector2 input){
        // Rotate object
        float rotation = objectMovementRotation * input.x;
        objectToMove.transform.localRotation = Quaternion.Euler(new Vector3(0,rotation,0));
    }

    public void calculateXAxisMoveBorderByScreenWidth() {
        //Get the screen width. This can be different depending on the screen
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // The Scale of the player
        float objectToMoveWidth = objectToMove.transform.localScale.x;

        //Subtract half of the characters width, so the character does not move out of the screen
        xAxisMovementBorder = Mathf.Abs(stageDimensions.x) - (objectToMoveWidth);
    }

    public void calculateYAxisMoveBorderByScreenHeight() {
        //Get the screen width. This can be different depending on the screen
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // The Scale of the player
        float objectToMoveWidth = objectToMove.transform.localScale.y;

        //Subtract half of the characters width, so the character does not move out of the screen
        yAxisMovementBorderMin = -stageDimensions.y + (objectToMoveWidth);
        yAxisMovementBorderMax = 0 - (stageDimensions.y / 5);
    }
    public void calculateXAxisMoveBorderBySpawner() {
        // Get the last spawn position of the spawner, which is the most outer spawn position.
        // Sets the move border based on that
        Transform lastSpawnPoint = spawner.spawnPoints[spawner.spawnPoints.Count - 1];
        float lastSpawnPointXPos = lastSpawnPoint.position.x;

        //Subtract half of the characters width, so the character does not move out of the screen
        xAxisMovementBorder = Mathf.Abs(lastSpawnPointXPos);
    }


    private void loadPreferences() {
        if (PlayerPrefs.HasKey(PrefKeys.SENSITIVITY.ToString())) {
            float sensitivity = PlayerPrefs.GetFloat(PrefKeys.SENSITIVITY.ToString(),1);
            this.moveSpeedXAxis *= sensitivity;
        }
    }

}
