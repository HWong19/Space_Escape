using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillBullets : _PowerUps {

    BulletController bulletScript;

    // Use this for initialization
    void Start () {
        base.Start();
	}

    protected override void activate(PlayerScript player) {
        bulletScript = player.gameObject.GetComponent<BulletController>();

        bulletScript.setBulletsLeft(bulletScript.maxBullets);

        deleteSelf();

    }

    public void deleteSelf() {
        base.deleteSelf();
    }

    

}
