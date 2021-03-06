﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : _PowerUps {

    public float duration = 5f;
    public float speedBoost = 2f; // Speed increase
    public float speedLimit = 20f;
    public AudioClip speedSound;
    AudioSource speedUpSound;

    protected bool speedUp = true;

    private void Awake() {
        
    }

    // Use this for initialization
    void Start () {
        replaceWhenCollectedAgain = false;
        

        base.Start();
	}

    protected override void activate(PlayerScript player) {
        StartCoroutine(startSpeedUp(player, speedUp));
    }

    private IEnumerator startSpeedUp(PlayerScript player, bool speedingUp) {
        float initialSpeed = player.speed;

        speedUpSound = GetComponent<AudioSource>();
        if (speedSound)
            speedUpSound.PlayOneShot(speedSound, 1f);

        if (speedingUp ? initialSpeed >= speedLimit : initialSpeed <= speedLimit) {
            float differenceInSpeed = initialSpeed - speedLimit;
            player.speed = speedLimit;
            yield return new WaitForSeconds(duration);
            //player.speed -= speedBoost;

        }
        else {
            player.speed += speedBoost;
            yield return new WaitForSeconds(duration);
            player.speed -= speedBoost;
        }


        deleteSelf();
    }

    public void deleteSelf() {
        base.deleteSelf();
    }
}
