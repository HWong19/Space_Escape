using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillBullets : _PowerUps {

    BulletController bulletScript;
    public AudioClip reloadSound;
    AudioSource reloadComp;

    private void Awake() {
        reloadComp = GetComponent<AudioSource>();
    }

    void Start () {
        base.Start();
	}

    protected override void activate(PlayerScript player) {
        bulletScript = player.gameObject.GetComponent<BulletController>();

        bulletScript.setBulletsLeft(bulletScript.maxBullets);

        reloadComp.PlayOneShot(reloadSound, 1f);

        deleteSelf();
    }

    public void deleteSelf() {
        Destroy(gameObject, 1f);
    }

    

}
