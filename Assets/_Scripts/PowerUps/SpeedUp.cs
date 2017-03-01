﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : _PowerUps {

    public float duration = 5f;
    public float speedBoost = 10f; // Speed increase

	// Use this for initialization
	void Start () {
        base.Start();
	}

    protected override void activate(PlayerScript player) {
        StartCoroutine("startSpeedUp", player);
    }

    private IEnumerator startSpeedUp(PlayerScript player) {
        float initialSpeed = player.speed;



        player.speed += speedBoost;
        yield return new WaitForSeconds(duration);
        player.speed -= speedBoost;


        Destroy(this);
    }

}