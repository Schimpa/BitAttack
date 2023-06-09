using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSrc;

    public AudioClip shootSound;
    public AudioClip levelUpSound;
    public AudioClip deadSound;
    public AudioClip clickSound;


    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
     
    }

    public void playShootSound() {
        audioSrc.PlayOneShot(shootSound);
    }

    public void playLevelUpSound() {
        audioSrc.PlayOneShot(levelUpSound);
    }

    public void playDeadSound() {
        audioSrc.PlayOneShot(deadSound);
    }

    public void playClickSound() {
        audioSrc.PlayOneShot(clickSound);
    }
}
