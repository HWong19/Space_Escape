﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOtherForward : _PowerUps {

    PlayerScript currentPlayer;
    PlayerScript otherPlayer;

    public float pushPower = 10f;
    public float pushDuration = .5f;

    public string player1ActivateButton;
    public string player2ActivateButton;

    private IEnumerator pushCoroutine;

    // Use this for initialization
    void Start () {
        
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(player1ActivateButton) && currentPlayer.playerID == 1) ||
            (Input.GetKeyDown(player2ActivateButton) && currentPlayer.playerID == 2) ) {

            gameObject.GetComponent<ParticleSystem>().Stop();
            StartCoroutine(pushCoroutine);

        }
    }

    protected override void activate(PlayerScript player) {
        currentPlayer = player;
        otherPlayer = OppositePlayer.getOppositePlayer(player);
        transform.position += new Vector3(0, 0, -.5f); // Just to push the particle effects towards the camera so it shows more

        gameObject.GetComponent<ParticleSystem>().Play();
        pushCoroutine = applyPushVelocity();
    }

    private IEnumerator applyPushVelocity() {
        float timePassed = 0f;

        Rigidbody otherRB = otherPlayer.GetComponent<Rigidbody>();
        Vector3 moveOffset = new Vector3(pushPower, 0, 0) * Time.deltaTime;

        while (timePassed < pushDuration) {

            otherRB.MovePosition(otherRB.gameObject.transform.position + moveOffset);

            yield return 0;
            timePassed += Time.deltaTime;
        }

        otherRB.velocity = Vector3.zero;
        deleteSelf();
    }

    public void deleteSelf() {
        StopCoroutine(pushCoroutine);
        base.deleteSelf();
    }
}