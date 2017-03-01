using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {


	public int playerID;
	public float speed;
	public int startingHealth;
	public Slider hpBar;
	public Text hpText;

    public _PowerUps activatedPowerUp = null;

	private float currentHealth;
	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		hpText.text = "Health: " + currentHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (playerID == 1) {
            print(speed);
			if (Input.GetKey ("w")) {
				transform.Translate (new Vector3 (0f, speed * Time.deltaTime, 0f));
			} else if (Input.GetKey ("s")) {
				transform.Translate (new Vector3 (0f, -speed * Time.deltaTime, 0f));
			}
		} else if (playerID == 2) {
			if (Input.GetKey ("up")) {
				transform.Translate (new Vector3 (0f, speed * Time.deltaTime, 0f));
			} else if (Input.GetKey ("down")) {
				transform.Translate (new Vector3 (0f, -speed * Time.deltaTime, 0f));
			}
		}

		if (transform.position.y < -4.5f) {
			transform.position = new Vector3 (transform.position.x, -4.5f, 0f);
		} else if (transform.position.y > 4.5f) {
			transform.position = new Vector3 (transform.position.x, 4.5f, 0f);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Obstacle"))
		{
			currentHealth = currentHealth - 1;
			hpBar.value = currentHealth/startingHealth;
			hpText.text = "Health: " + currentHealth;
			if (currentHealth == 0) {
				//gameover
			}
		} else {
            _PowerUps power = other.GetComponent<_PowerUps>();
            if (!power)
                return;
            gameObject.AddComponent(   power.GetType()   );
            Destroy(other.gameObject);
        }
	}
}
