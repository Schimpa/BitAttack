using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorParticleSystem : MonoBehaviour {

    public ParticleSystem clickParticles;
    public BoxCollider2D boxCollider;

    // Update is called once per frame
    void Update() {
        Vector3 newMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newMousePos.z = 2;

        this.gameObject.transform.position = newMousePos;  // No z POS

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            //clickParticles.transform.position = newMousePos;
            clickParticles.Play();
            boxCollider.enabled = true;
        } else if (Input.GetKeyUp(KeyCode.Mouse0)) {
            boxCollider.enabled = false;
        }
    }
}
