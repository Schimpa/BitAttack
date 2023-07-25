using UnityEngine;

public class MovementController : MonoBehaviour {

    public float moveSpeed;
    public float joystickSensitivity;

    public float objectMovementRotation;

    public FixedJoystick joystickRight;
    public FixedJoystick joystickLeft;
    public GameObject objectToMove;

    // The maximum value, in which the character can move on the play field (Both directions)
    private float xAxisMovementBorder;

    private GameMode gameMode = GameMode.MOBILE;

    void Awake() {
        setJoyStickActive(true);
        loadPreferences();
    }

    void Update() { if (objectToMove == null) return;
        float xAxisInput = getXAxisInput();
        float xPos = objectToMove.transform.position.x;

        validateMovementConditionsBasedOnInput(xAxisInput, xPos);

        updateObjectRotation(-xAxisInput);

        Debug.Log("Mouse Position: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private float getXAxisInput() {
        float xAxisInput = 0f;

        if ( (SystemInfo.deviceType == DeviceType.Handheld) && (joystickRight.isPressed) ) {
            xAxisInput = 1;
        } else if ((SystemInfo.deviceType == DeviceType.Handheld) && (joystickLeft.isPressed)) {
            xAxisInput = -1;
        } else if (gameMode == GameMode.MOBILE) {   
            // The input from left and right arrow is taken
            xAxisInput = Input.GetAxis("Horizontal");
        } else if (gameMode == GameMode.PC) {
            // The camera is rotated by 90°, so the vertical input from up/down arrow is taken
            xAxisInput = -Input.GetAxis("Vertical");
        }

        return xAxisInput;
    }

    private void validateMovementConditionsBasedOnInput(float xAxisInput, float xPos) {
        if (Mathf.Abs(xPos) > xAxisMovementBorder) {
            if ((xPos < -xAxisMovementBorder) && xAxisInput > 0) {
                // Allow player to move from left (outside border) to the right back into the area
                updateObjectPosition(xAxisInput);
            } else if ((xPos > xAxisMovementBorder) && xAxisInput < 0) {
                // Allow player to move from right (outside border) to the left back into the area
                updateObjectPosition(xAxisInput);
            }
        } else {
            updateObjectPosition(xAxisInput);
        }
    }

    private void updateObjectPosition(float xAxisInput) {
        Vector3 moveVector = new Vector3(xAxisInput, 0, 0) * moveSpeed * Time.deltaTime;

        objectToMove.transform.Translate(moveVector);
        objectToMove.transform.position = new Vector3(
            objectToMove.transform.position.x, 
            objectToMove.transform.position.y, 
            0
        );
    }

    private void updateObjectRotation(float horizontalInput){
        // Rotate object
        float rotation = objectMovementRotation * horizontalInput;
        objectToMove.transform.localRotation = Quaternion.Euler(new Vector3(0,rotation,0));
    }

    public void calculateXAxisMoveBorder() {
        //Get the screen width. This can be different depending on the screen
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // The Scale of the player
        float objectToMoveWidth = objectToMove.transform.localScale.x;

        //Subtract half of the characters width, so the character does not move out of the screen
        xAxisMovementBorder = Mathf.Abs(stageDimensions.x) - (objectToMoveWidth);

    }
    private void loadPreferences() {
        if (PlayerPrefs.HasKey(PrefKeys.SENSITIVITY.ToString())) {
            float sensitivity = PlayerPrefs.GetFloat(PrefKeys.SENSITIVITY.ToString(),1);
            this.moveSpeed *= sensitivity;
        }
    }

    public void setJoyStickActive(bool value) {
        /**
         * Sets the joystick active or inactive. But only active if it is a mobile device
         */
        if (value == true && SystemInfo.deviceType == DeviceType.Handheld) {
            joystickRight.gameObject.SetActive(true);
            joystickLeft.gameObject.SetActive(true);
        } else {
            joystickRight.gameObject.SetActive(false);
            joystickLeft.gameObject.SetActive(false);
        }
        
    }

    public void setGameMode(GameMode newMode) {
        this.gameMode = newMode;
    }

}
