﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdelete : MonoBehaviour {

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Obstacle") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Obstacle") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
