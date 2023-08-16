using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmoothCameraTransition : MonoBehaviour {

    public GameObject mainCamera;
    public Transform startPosition;
    public Transform endPosition;

    [SerializeField][Header("Shall transition be from startPos to endPos or from endPos to startPos")]
    CameraTransitionMovementDirection moveDirection;

    [Header("Shall the camera transition be done on start?")]
    public bool transitionOnStart;

    [Header("What shall happen when the transition finished?")]
    public UnityEvent onFadeFinished;

    [Header("Duration of the camera movement")]
    public float transitionDuration;

    private float transitionTimer;

    private bool isCameraTransitionActive;

    void Start() {
        if (transitionOnStart) {
            isCameraTransitionActive = true;
        } else {
            isCameraTransitionActive = false;
        }
        resetCamera();
    }

    // Update is called once per frame
    void Update() { if (isCameraTransitionActive == false) return;
        doCameraTransition();
    }

    public void resetCamera() {
        transitionTimer = 0f;
        if (moveDirection == CameraTransitionMovementDirection.FORWARD) {
            mainCamera.transform.position = startPosition.position;
        } else {
            mainCamera.transform.position = endPosition.position;
        }
    }

    public void startCameraTransition() {
        resetCamera();
        this.isCameraTransitionActive = true;
    }

    public void reverseMoveDirection() {
        if (moveDirection == CameraTransitionMovementDirection.FORWARD) {
            moveDirection = CameraTransitionMovementDirection.BACKWARD;
        } else {
            moveDirection = CameraTransitionMovementDirection.FORWARD;
        }
    }

    private void doCameraTransition() {
        transitionTimer += Time.deltaTime;
        float lerpPos = transitionTimer / transitionDuration;

        if (lerpPos >= 1f) {
            lerpPos = 1f;
            isCameraTransitionActive = false;
            onFadeFinished.Invoke();
        }

        Vector3 currentCameraPos;
        if (moveDirection == CameraTransitionMovementDirection.FORWARD) {
            currentCameraPos = Vector3.Lerp(startPosition.position, endPosition.position, lerpPos);
        } else {
            currentCameraPos = Vector3.Lerp(endPosition.position, startPosition.position, lerpPos);
        }
        mainCamera.transform.position = currentCameraPos;
    }

}
enum CameraTransitionMovementDirection {
    FORWARD,
    BACKWARD
}
