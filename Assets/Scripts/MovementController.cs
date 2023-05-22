using UnityEngine;

public class MovementController : MonoBehaviour {

    public float moveSpeed;
    public float joystickSensitivity;

    // The maximum value, in which the character can move on the X-Axis (Both directions)
    private float xAxisMovementBorder;

    private FixedJoystick joystick;

    void Start() {
        calculateXAxisMoveBorder();

        joystick = GameObject.Find("Joystick").GetComponent<FixedJoystick>();
        if (SystemInfo.deviceType == DeviceType.Handheld) {
            joystick.gameObject.SetActive(true);
        } else {
            joystick.gameObject.SetActive(false);
        }
    }

    void Update() {
        float horizontalInput = 0f;

        if (SystemInfo.deviceType == DeviceType.Handheld) {
            horizontalInput = joystick.Horizontal * joystickSensitivity;
        } else {
            horizontalInput = Input.GetAxis("Horizontal");
        }

        float verticalInput = Input.GetAxis("Vertical");

        float xPos = this.transform.position.x;

        if (Mathf.Abs(xPos) > xAxisMovementBorder) {
            if ( (xPos < - xAxisMovementBorder) && horizontalInput > 0) {
                // Allow player to move from left (outside border) to the right back into the area
                updateTransform(horizontalInput);
            } else if ( (xPos > xAxisMovementBorder) && horizontalInput < 0) {
                // Allow player to move from right (outside border) to the left back into the area
                updateTransform(horizontalInput);
            } 
        } else {
            updateTransform(horizontalInput);
        }

    }

    void updateTransform(float horizontalInput) {
        Vector3 moveVector = new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;

        transform.Translate(moveVector);
    }

    void calculateXAxisMoveBorder() {
        //Get the screen width. This can be different depending on the screen
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // The Scale of the player
        float characterWidth = this.transform.localScale.x;

        //Subtract half of the characters width, so the character does not move out of the screen
        xAxisMovementBorder = stageDimensions.x - (characterWidth / 2); 

    }

}
