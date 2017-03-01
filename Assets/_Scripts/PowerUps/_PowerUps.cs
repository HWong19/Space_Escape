using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _PowerUps : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        PlayerScript player = GetComponent<PlayerScript>();
        if (player)
            activate(player);
    }

    //void OnTriggerEnter(Collider collided) {
    //    if (collided.tag == "Player") {
    //        onTouched(collided.gameObject.AddComponent<>);
    //    }
    //}

    protected abstract void activate(PlayerScript player);
}
