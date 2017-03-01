using System.Collections;
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

	private float currentHealth;
    private bool shieldUp;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		hpText.text = "Health: " + currentHealth;

        rgb = GetComponent<Rigidbody>();
        initialColor = GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {

		if (playerID == 1) {
            
			if (Input.GetKey ("w")) {
                rgb.MovePosition(transform.position + new Vector3(0f, speed * Time.deltaTime, 0f));
				//transform.Translate (new Vector3 (0f, speed * Time.deltaTime, 0f));
			} else if (Input.GetKey ("s")) {
                rgb.MovePosition(transform.position + new Vector3(0f, -speed * Time.deltaTime, 0f));
                //transform.Translate (new Vector3 (0f, -speed * Time.deltaTime, 0f));
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
		if(other.gameObject.CompareTag("Obstacle") && !shieldUp)
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

    public void changeShieldUp(bool activate) {
        shieldUp = activate;
    }
}
