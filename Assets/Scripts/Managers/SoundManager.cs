using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSrc;

    public AudioClip shootSound01;
    public AudioClip shootSound02;
    public AudioClip shootSound03;
    public AudioClip levelUpSound;
    public AudioClip damageSound;
    public AudioClip deadSound;
    public AudioClip winSound;
    public AudioClip clickSound;
    public AudioClip obstacleHitSound;
    public AudioClip selectionFailedSound;
    public AudioClip selectionSuccessfullSound;

    void Start() {
        checkSoundPreference();
    }

    public void playShootSound01() {
        audioSrc.PlayOneShot(shootSound01);
    }

    public void playShootSound02() {
        audioSrc.PlayOneShot(shootSound02);
    }

    public void playShootSound03() {
        audioSrc.PlayOneShot(shootSound03);
    }

    public void playLevelUpSound() {
        audioSrc.PlayOneShot(levelUpSound);
    }

    public void playDeadSound() {
        audioSrc.PlayOneShot(deadSound);
    }

    public void playWinSound() {
        audioSrc.PlayOneShot(winSound);
    }

    public void playClickSound() {
        audioSrc.PlayOneShot(clickSound);
    }

    public void playSelectionFailedSound() {
        audioSrc.PlayOneShot(selectionFailedSound);
    }

    public void playSelectionSuccessfullSound() {
        audioSrc.PlayOneShot(selectionSuccessfullSound);
    }

    public void playObstacleDestroyedSound() {
        audioSrc.PlayOneShot(obstacleHitSound);
    }

    public void playObstacleHitSound() {
        audioSrc.PlayOneShot(damageSound);
    }

    public void checkSoundPreference() {
        if (PlayerPrefs.HasKey(PrefKeys.SOUND_IS_ON.ToString())) {
            int isSoundOn = PlayerPrefs.GetInt(PrefKeys.SOUND_IS_ON.ToString());

            if (isSoundOn == 1) {
                audioSrc.mute = false;
            } else {
                audioSrc.mute = true;
            }
        }
    }
}
