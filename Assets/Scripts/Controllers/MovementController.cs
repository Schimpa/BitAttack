using UnityEngine;

public class MovementController : MonoBehaviour {

    public float moveSpeed;
    public float joystickSensitivity;

    [Range(0,1)]
    public float joystickThreshold; //The value, at which the input from the joystick will be registered

    public float objectMovementRotation;

    public FixedJoystick joystick;
    public GameObject objectToMove;

    // The maximum value, in which the character can move on the X-Axis (Both directions)
    private float xAxisMovementBorder;

    void Awake() {
        setJoyStickActive(true);
        loadSensitivityPreference();
    }

    void Update() { if (objectToMove == null) return;
        float horizontalInput = 0f;

        if (SystemInfo.deviceType == DeviceType.Handheld) {
            if (Mathf.Abs(joystick.Horizontal) > joystickThreshold) {
                horizontalInput = joystick.Horizontal * joystickSensitivity;
            }       
        } else {
            horizontalInput = Input.GetAxis("Horizontal");
        }

        float xPos = objectToMove.transform.position.x;

        if (Mathf.Abs(xPos) > xAxisMovementBorder) {
            if ( (xPos < - xAxisMovementBorder) && horizontalInput > 0) {
                // Allow player to move from left (outside border) to the right back into the area
                updateObjectPosition(horizontalInput);
            } else if ( (xPos > xAxisMovementBorder) && horizontalInput < 0) {
                // Allow player to move from right (outside border) to the left back into the area
                updateObjectPosition(horizontalInput);
            } 
        } else {
            updateObjectPosition(horizontalInput);
        }

        updateObjectRotation(-horizontalInput);

    }

    private void updateObjectPosition(float horizontalInput) {
        Vector3 moveVector = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;

        objectToMove.transform.Translate(moveVector);
        objectToMove.transform.position = new Vector3(
            objectToMove.transform.position.x, 0, 0
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
        xAxisMovementBorder = stageDimensions.x - (objectToMoveWidth / 2); 

    }
    private void loadSensitivityPreference() {
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
            joystick.gameObject.SetActive(true);
        } else {
            joystick.gameObject.SetActive(false);
        }
        
    }

}
