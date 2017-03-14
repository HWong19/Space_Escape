using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownForOther : SpeedUp {

	// Use this for initialization
	void Start () {
        speedBoost *= -1;
        speedUp = false;

        base.Start();
        
	}

    protected override void activate(PlayerScript player) {
        base.activate(OppositePlayer.getOppositePlayer(player));
    }
}
