using UnityEngine;

public class EnemyShipMovementController : MonoBehaviour {


    public float moveSpeed;

    [Header("At which X-Difference the enemy ship starts to move")]
    public float moveThreshold;

    public float objectMovementRotation;

    public GameObject enemyShip;

    private GameObject playerShip;

    private void Start() {
        if (playerShip == null) {
            playerShip = GameObject.Find("Player");
        }
    }

    void Update() {
        if (playerShip == null) {
            playerShip = GameObject.Find("Player");
        } else {
            checkPlayerPosition();
        }
    }

    void checkPlayerPosition() {
        Vector2 enemyShipPos = enemyShip.transform.position;
        Vector2 playerPos = playerShip.transform.position;
       
        if (Mathf.Abs(enemyShipPos.x - playerPos.x) < moveThreshold) {
            updateObjectRotation(new Vector2(0,0));
            return;
        }

        Vector2 moveVector = new Vector2(0, 0);
        if (enemyShipPos.x < playerPos.x) {
            // Player ship is higher(PC) / on the left side(Mobile)
            moveVector = new Vector2(1, 0) * moveSpeed;
        } else {
            // Player ship is lower(PC) / on the right side(Mobile)
            moveVector = new Vector2(1, 0) * -moveSpeed;
        }

        updateObjectPosition(moveVector);
        updateObjectRotation(moveVector);
    }


    private void updateObjectPosition(Vector2 axisInput) {
        Vector3 moveVector = axisInput  * Time.deltaTime * 10;

        enemyShip.transform.Translate(moveVector);
        enemyShip.transform.position = new Vector3(
            enemyShip.transform.position.x, 
            enemyShip.transform.position.y, 
            0
        );
    }

    private void updateObjectRotation(Vector2 input){
        // Rotate object

        float rotation = objectMovementRotation * input.x;
        enemyShip.transform.localRotation = Quaternion.Euler(new Vector3(-180, rotation, 0));
    }



}
