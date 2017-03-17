using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    
    private Rigidbody2D rb2d;

    [SerializeField]
    private float scroll_speed = -1.5f; //default scroll is at -1.5f

    // Use this for initialization
    void Start() {
        if (Time.timeScale != 1) {
            Time.timeScale = 1;
        }
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(scroll_speed, 0);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
