﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

    public Slider bulletSlider;
    public Text bulletRemainingText;

    public GameObject shotPrefab;
    public GameObject exit_Point;
    public float speed = 10.0f;
    public float fireRate = 0.5f;
    public int maxBullets;
    public AudioClip fireSound;
    AudioSource playerSound;

    private float time = 0.0f;
    private int remainingBullets;

    private void Awake() {
        playerSound = GetComponent<AudioSource>();
    }

    void Start () {
        time = Time.time;

        bulletSlider.maxValue = maxBullets;
        remainingBullets = maxBullets;

        bulletSlider.value = remainingBullets;
        updateBulletText();
    }
	
	void Update () {
        if (Time.time - time > fireRate && remainingBullets > 0) {
            
            if (Input.GetKeyDown("space") && exit_Point.name == "Player1") {
                Fire();
                playerSound.PlayOneShot(fireSound, 1f);
            }
            else if (Input.GetKeyDown("[0]") && exit_Point.name == "Player2") {
                Fire();
                playerSound.PlayOneShot(fireSound, 1f);
            }
        }
    }

    private void Fire() {
        time = Time.time;
		GameObject bullet_inst = Instantiate(shotPrefab, exit_Point.transform.position + new Vector3(1f,0.5f,-0f), Quaternion.identity);
        Rigidbody bulletRB = bullet_inst.GetComponent<Rigidbody>();
		bulletRB.velocity = transform.TransformDirection(Vector3.forward * speed);
        bulletRB.velocity = new Vector3(bulletRB.velocity.x, bulletRB.velocity.y, 0);

        --remainingBullets;
        updateBulletText();

    }

    private void updateBulletText() {
        bulletRemainingText.text = "Bullets: " + remainingBullets;
        bulletSlider.value = remainingBullets;
    }

    public void setBulletsLeft(int newAmount) {
        remainingBullets = newAmount;
        updateBulletText();
    }

}


