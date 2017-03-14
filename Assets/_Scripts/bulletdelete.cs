using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdelete : MonoBehaviour {

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Obstacle") {
            print("Collided");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Obstacle") {
            print("Triggered");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
