using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : _PowerUps {

    public float duration = 5f;

    // Use this for initialization
    void Start() {
        base.Start();
    }

    protected override void activate(PlayerScript player) {
        StartCoroutine("activateShieldUp", player);
    }

    private IEnumerator activateShieldUp(PlayerScript player) {
        Renderer playerRenderer = player.gameObject.GetComponent<Renderer>();

        player.changeShieldUp(true);
        playerRenderer.material.color = Color.white;

        yield return new WaitForSeconds(duration);

        if (player.GetComponents<ShieldUp>().Length == 1) {
            player.changeShieldUp(false);
            playerRenderer.material.color = player.initialColor;
        }

        Destroy(this);
    }

}
