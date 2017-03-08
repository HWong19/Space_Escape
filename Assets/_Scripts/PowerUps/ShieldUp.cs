using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : _PowerUps {

    public float duration = 5f;

    private IEnumerator flashCoroutine = null;
    Renderer playerRenderer;


    // Use this for initialization
    void Start() {
        replaceWhenCollectedAgain = true;

        base.Start();
    }

    protected override void activate(PlayerScript player) {
        playerRenderer = player.gameObject.GetComponent<Renderer>();

        Color shieldColor = Color.green;

        flashCoroutine = player.flashColor(duration, .1f, player.initialColor, shieldColor);

        StartCoroutine("activateShieldUp", player);
    }

    private IEnumerator activateShieldUp(PlayerScript player) {
        
        player.changeShieldUp(true);
        
        ShieldUp currentShield = player.GetComponentInChildren<ShieldUp>();
        
        if (true) {
            
            StartCoroutine(flashCoroutine);
            yield return new WaitForSeconds(duration);
            player.changeShieldUp(false);
            playerRenderer.material.color = player.initialColor;
        } else {
                
        }


            if (player.GetComponents<ShieldUp>().Length == 1) {
            
        }

        Destroy(gameObject);
    }

    public override void deleteSelf() {
        StopCoroutine(flashCoroutine);
        Destroy(gameObject);
    }

}
