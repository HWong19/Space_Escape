using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : _PowerUps {

    public float duration = 5f;
    public float speedBoost = 2f; // Speed increase
    public float speedLimit = 20f;

    protected bool speedUp = true;

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


        Destroy(gameObject);
    }

    public override void deleteSelf() {

    }
}
