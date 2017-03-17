using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {

    private float groundHorizontalLength;


    // Use this for initialization
    void Start() {

        groundHorizontalLength = 24.58f; //initialized pixel dimension divided by 100. e.g. 2048x1024 -> 20.48
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < -groundHorizontalLength) {
            RepositionBackground();
        }
    }

    private void RepositionBackground() {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
