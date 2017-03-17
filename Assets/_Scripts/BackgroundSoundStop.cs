using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundStop : MonoBehaviour {

    
    AudioSource backgroundSound;

    private void Awake() {
        backgroundSound = GetComponent<AudioSource>();
    }

    void Update () {
		if (GameController.instance.gameOver) {
            backgroundSound.Stop();
        }
	}
}
