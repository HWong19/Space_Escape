using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownForOther : SpeedUp {
    
    AudioSource SlowDownSound;

    public void Awake() {
        SlowDownSound = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        SlowDownSound.PlayOneShot(speedSound, 0.8f);
        speedBoost *= -1;
        speedUp = false;

        base.Start();
        
	}

    protected override void activate(PlayerScript player) {
        base.activate(OppositePlayer.getOppositePlayer(player));
    }
}
