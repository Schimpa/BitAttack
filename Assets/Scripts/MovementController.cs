using UnityEngine;

public class MovementController : MonoBehaviour {

    public float moveSpeed;

    // The maximum value, in which the character can move on the X-Axis (Both directions)
    private float movementXBorder;

    void Start() {
        calculateMovementXBorder();
    }

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float xPos = this.transform.position.x;

        if (Mathf.Abs(xPos) > movementXBorder) {
            if ( (xPos < - movementXBorder) && horizontalInput > 0) {
                // Allow player to move from left (outside border) to the right back into the area
                updateTransform(horizontalInput, verticalInput);
            } else if ( (xPos > movementXBorder) && horizontalInput < 0) {
                // Allow player to move from right (outside border) to the left back into the area
                updateTransform(horizontalInput, verticalInput);
            } 
        } else {
            updateTransform(horizontalInput, verticalInput);
        }

    }

    void updateTransform(float horizontalInput, float verticalInput) {
        Vector3 moveVector = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        transform.Translate(moveVector);
    }

    void calculateMovementXBorder() {
        //Get the screen width. This can be different depending on the screen
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // The Scale of the player
        float characterWidth = this.transform.localScale.x;

        //Subtract half of the characters width, so the character does not move out of the screen
        movementXBorder = stageDimensions.x - (characterWidth / 2); 

    }

}
