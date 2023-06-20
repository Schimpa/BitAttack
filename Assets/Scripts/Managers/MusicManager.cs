using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioSource audioSrc;

    public AudioClip music;

    public bool resetClipOnReplay;  // Set this to true to replay the music after the level restarts. Else the clip keeps playing
    public bool playOnStart;        // If this is set to true, the assigned music clip is played at start

    public void Start() {
        if (music != null) {    // Load clip
            audioSrc.clip = music;
            audioSrc.Play();
        }

        if (playOnStart && audioSrc.clip == null) {
            audioSrc.Play();    // Play music
        }

        checkMusicPreference();
    }

    public void playMusic() {
        setPlayVolume(1);

        if (resetClipOnReplay) {
            audioSrc.Stop();
            audioSrc.PlayOneShot(music);
        } else { 
            if (audioSrc.clip == null) {
                audioSrc.clip = music;
            }
            if (audioSrc.isPlaying == false) {
                audioSrc.Play();
            }          
        }       
    }

    public void setPlayVolume(float value) {
        audioSrc.volume = value;
    }

    public void checkMusicPreference() {
        if (PlayerPrefs.HasKey(PrefKeys.MUSIC_IS_ON.ToString())) {
            int isMusicOn = PlayerPrefs.GetInt(PrefKeys.MUSIC_IS_ON.ToString());

            if (isMusicOn == 1) {
                audioSrc.mute = false;
            } else {
                audioSrc.mute = true;
            }
        }
    }

}
