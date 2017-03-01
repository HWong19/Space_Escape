using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _PowerUps : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    //void OnTriggerEnter(Collider collided) {
    //    if (collided.tag == "Player") {
    //        onTouched(collided.gameObject.AddComponent<>);
    //    }
    //}

    protected abstract void activate(PlayerScript player);
}
