using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _PowerUps : MonoBehaviour {

    public bool replaceWhenCollectedAgain;

	// Use this for initialization
	protected void Start () {
        PlayerScript player = transform.parent.GetComponent<PlayerScript>();
        if (player) {
            //if (replaceWhenCollectedAgain)
            //    replace(player);
            //else
                activate(player);

        }
    }

    //void OnTriggerEnter(Collider collided) {
    //    if (collided.tag == "Player") {
    //        onTouched(collided.gameObject.AddComponent<>);
    //    }
    //}

    protected abstract void activate(PlayerScript player);

    public void deleteSelf() {
        Destroy(gameObject);
    }
}
