using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositePlayer : MonoBehaviour {
    
    public static PlayerScript getOppositePlayer(PlayerScript currentPlayer) {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player") ) {
            PlayerScript checkedScript = player.GetComponent<PlayerScript>();
            if (checkedScript.playerID != currentPlayer.playerID)
                return checkedScript;
        }
        return null;
        
    }

}
