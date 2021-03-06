﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : _PowerUps {

    PlayerScript playerRef;
    public float duration = 5f;
    public AudioClip shieldSound;
    AudioSource shieldsoundSource;

    private IEnumerator flashCoroutine = null;
    Renderer playerRenderer;


    private void Awake() {
        
    }

    // Use this for initialization
    void Start() {
        replaceWhenCollectedAgain = true;
        shieldsoundSource = GetComponent<AudioSource>();

        base.Start();
    }

    protected override void activate(PlayerScript player) {
        playerRef = player;
        playerRenderer = player.gameObject.GetComponent<Renderer>();

        Color shieldColor = Color.green;

        flashCoroutine = player.flashColor(duration, .1f, player.initialColor, shieldColor);

        StartCoroutine("activateShieldUp", player);
    }

    private IEnumerator activateShieldUp(PlayerScript player) {
        
        player.changeShieldUp(true);
        
        ShieldUp currentShield = player.GetComponentInChildren<ShieldUp>();
            
        StartCoroutine(flashCoroutine);

        shieldsoundSource.PlayOneShot(shieldSound, 1f);
        yield return new WaitForSeconds(duration);
        player.changeShieldUp(false);
        player.resetColor();

        Destroy(gameObject);
    }

    public void deleteSelf() {
        StopCoroutine(flashCoroutine);
        playerRef.resetColor();
        Destroy(gameObject);
    }

}
