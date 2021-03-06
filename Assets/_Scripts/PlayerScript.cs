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

    private float playerHalfSizeX;
    private float playerXLimit;
	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		hpText.text = "Health: " + currentHealth;

        rgb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        initialColor = rend.material.color;

        invincible = false;

        playerHalfSizeX = .5f;
        playerXLimit = GameController.camBoundsX - playerHalfSizeX;

        print(playerXLimit + " | " + GameController.camBoundsX);

        if (!canMoveRB(Vector3.zero)) {
            Vector3 newStartVector = transform.position;
            newStartVector.x = -playerXLimit;
            transform.position = newStartVector;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (playerID == 1) {
            vertMovement = Input.GetAxis("VerticalKeyPad");
            horiMovement = Input.GetAxis("HorizontalKeyPad");
            
            //print("Player1: " + vertMovement + " | " + horiMovement);

        }

        else if (playerID == 2) {
            vertMovement = Input.GetAxis("VerticalArrows");
            horiMovement = Input.GetAxis("HorizontalArrows");
            //print("Player2: " + vertMovement + " | " + horiMovement);
        }

        Vector3 moveDirection = new Vector3(horiMovement, vertMovement);
        if (moveDirection.magnitude > 1)
            Vector3.Normalize(moveDirection);
        Vector3 moveOffset = moveDirection * speed * Time.deltaTime;
        
        if (canMoveRB(moveOffset)) { // Only X
            rgb.MovePosition(transform.position + moveOffset);
        } else { // So, have to keep moving Y. Y-Axis has walls so moving this is okay
            Vector3 canceledXOffset = moveOffset;
            canceledXOffset.x = 0;
            rgb.MovePosition(transform.position + canceledXOffset);
        }

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
		} else if (other.gameObject.tag == "PowerUp") {
            pickUpPowerUp(other.gameObject);

        }
	}

    private void pickUpPowerUp(GameObject powerUpPickup) {
        Transform powerUp = powerUpPickup.transform.GetChild(0);
        _PowerUps powerScript = powerUp.GetComponent<_PowerUps>();
        System.Type typeOfPower = powerScript.GetType();

        if (powerScript.replaceWhenCollectedAgain) {
            for (int child = 0; child < transform.childCount; ++child) {
                _PowerUps childPower = transform.GetChild(child).GetComponent<_PowerUps>();
                if (childPower) {
                    if (typeOfPower == childPower.GetType()) {
                        childPower.deleteSelf();
                        break;
                    }
                }
            }
        }

        powerUp.parent = gameObject.transform;
        powerUp.transform.position = gameObject.transform.position;
        powerUp.gameObject.SetActive(true);

        Destroy(powerUpPickup);
    }


    public void changeShieldUp(bool activate) {
        shieldUp = activate;
    }

    private IEnumerator makeInvincibleWhenHit() {
        invincible = true;

        float timePassed = 0f;
        float timeToPass = Time.deltaTime * 5;


        //For Flashing a certain Color:

        StartCoroutine(flashColor(invincibleTime, timeToPass, initialColor, new Color(.2f, .2f, .2f)));
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
        resetColor();
    }

    public void resetColor() {
        rend.material.color = initialColor;
    }

    public bool canMoveRB(Vector3 offset) {
        Vector3 newPos = transform.position + offset;
        return newPos.x > -playerXLimit && newPos.x < playerXLimit;
    }
         

}
