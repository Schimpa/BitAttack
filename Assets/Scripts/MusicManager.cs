using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioSource audioSrc;

    public AudioClip level01Music;

    public bool resetClipOnReplay;  // Set this to true to replay the music after the level restarts. Else the clip keeps playing
    public bool playOnStart;        // If this is set to true, the assigned music clip is played at start

    public void Start() {
        if (playOnStart && audioSrc.clip == null) {
            audioSrc.Play();
        }
    }

    public void playLevel01Music() {
        if (resetClipOnReplay) {
            audioSrc.Stop();
            audioSrc.PlayOneShot(level01Music);
        } else { 
            if (audioSrc.clip == null) {
                audioSrc.clip = level01Music;
            }
            if (audioSrc.isPlaying == false) {
                audioSrc.Play();
            }          
        }       
    }



}
