﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public Color initialColor;
	public int playerID;
	public float speed;
	public int startingHealth;
	public Slider hpBar;
	public Text hpText;

    private Rigidbody rgb;
    private Renderer rend;

	private float currentHealth;
    private bool shieldUp;
    private bool invincible;
    public float invincibleTime = 3f;

    private float horiMovement = 0f;
    private float vertMovement = 0f;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		hpText.text = "Health: " + currentHealth;

        rgb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        initialColor = rend.material.color;

        invincible = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (playerID == 1) {

            //if (Input.GetKey("w")) {
            //    vertMovement = 1;
            //    //rgb.MovePosition(transform.position + new Vector3(0f, speed * Time.deltaTime, 0f));
            //}
            //else if (Input.GetKey("s")) {
            //    //rgb.MovePosition(transform.position + new Vector3(0f, -speed * Time.deltaTime, 0f));
            //}
            //if (Input.GetKey("d")) {
            //    //rgb.MovePosition(transform.position + new Vector3(speed * Time.deltaTime, 0f));
            //}
            //else if (Input.GetKey("a")) {
            //    //rgb.MovePosition(transform.position + new Vector3(-speed * Time.deltaTime, 0f));
            //}

            vertMovement = Input.GetAxis("VerticalKeyPad");
            horiMovement = Input.GetAxis("HorizontalKeyPad");

            //print("Player1: " + vertMovement + " | " + horiMovement);

        }

        else if (playerID == 2) {
            //if (Input.GetKey("up")) {
            //    //rgb.MovePosition(transform.position + new Vector3(0f, speed * Time.deltaTime, 0f));

            //}
            //else if (Input.GetKey("down")) {
            //    //rgb.MovePosition(transform.position + new Vector3(0f, -speed * Time.deltaTime, 0f));
            //}
            //if (Input.GetKey("right")) {
            //    rgb.MovePosition(transform.position + new Vector3(speed * Time.deltaTime, 0f));
            //    print("here");
            //}
            //else if (Input.GetKey("left")) {
            //    rgb.MovePosition(transform.position + new Vector3(-speed * Time.deltaTime, 0f));
            //}

            vertMovement = Input.GetAxis("VerticalArrows");
            horiMovement = Input.GetAxis("HorizontalArrows");
            //print("Player2: " + vertMovement + " | " + horiMovement);
        }

        Vector3 moveDirection = new Vector3(horiMovement, vertMovement);
        if (moveDirection.magnitude > 1)
            Vector3.Normalize(moveDirection);
        Vector3 moveOffset = moveDirection * speed * Time.deltaTime;

        rgb.MovePosition(transform.position + moveOffset);

        //if (transform.position.y < -4.5f) {
        //    transform.position = new Vector3(transform.position.x, -4.5f, 0f);
        //}
        //else if (transform.position.y > 4.5f) {
        //    transform.position = new Vector3(transform.position.x, 4.5f, 0f);
        //}

    }

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Obstacle") && !shieldUp && !invincible)
		{
			currentHealth = currentHealth - 1;
			hpBar.value = currentHealth/startingHealth;
			hpText.text = "Health: " + currentHealth;
			if (currentHealth == 0) {
                GameController.instance.gameOver = true;
                GameController.instance.lost = playerID;
			}

            StartCoroutine(makeInvincibleWhenHit());
		} else {
            _PowerUps power = other.GetComponent<_PowerUps>();
            if (!power)
                return;
            gameObject.AddComponent(   power.GetType()   );
            Destroy(other.gameObject);
        }
	}

    public void changeShieldUp(bool activate) {
        shieldUp = activate;
    }

    private IEnumerator makeInvincibleWhenHit() {
        invincible = true;

        float timePassed = 0f;
        float timeToPass = Time.deltaTime * 5;


        //For Flashing a certain Color:

        StartCoroutine(flashColor(invincibleTime, timeToPass, rend.material.color, new Color(.2f, .2f, .2f)));
        yield return new WaitForSeconds(invincibleTime);

        //For Flashing them invisible

        //while (timePassed < invincibileTime) {
        //    rend.enabled = !rend.enabled;

        //    timePassed += timeToPass;
        //    yield return new WaitForSeconds(timeToPass);
        //}
        //rend.enabled = true;
        
        invincible = false;
    }

    public IEnumerator flashColor(float flashDuration, float flashSpeed, Color startColor, Color flashColor) {
        float timePassed = 0;
        
        //For Flashing a certain Color:

        while (timePassed < flashDuration) {
            //print("Flashing");
            rend.material.color = rend.material.color == flashColor ? startColor : flashColor;

            timePassed += flashSpeed;
            yield return new WaitForSeconds(flashSpeed);
        }
        rend.material.color = startColor;
    }

}
