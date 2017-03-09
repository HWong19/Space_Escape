using System.Collections;
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

    private float time = 0.0f;

    public int maxBullets = 3;
    private int remainingBullets;
    // Use this for initialization
    void Start () {
        time = Time.time;

        bulletSlider.maxValue = maxBullets;
        remainingBullets = maxBullets;

        bulletSlider.value = remainingBullets;
        updateBulletText();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time > fireRate && remainingBullets > 0) {
            
            if (Input.GetKeyDown("space") && exit_Point.name == "Player1") {

                Fire();
            }
            else if (Input.GetKeyDown("[0]") && exit_Point.name == "Player2") {
                Fire();
            }
        }
    }

    private void Fire() {
        time = Time.time;
        GameObject bullet_inst = Instantiate(shotPrefab, exit_Point.transform.position, Quaternion.identity);
        bullet_inst.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.right * speed);

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


