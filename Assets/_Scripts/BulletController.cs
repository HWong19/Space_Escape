using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {


    public GameObject shotPrefab;
    public GameObject exit_Point;
    public float speed = 10.0f;
    public float fireRate = 0.5f;

    private float time = 0.0f;
    // Use this for initialization
    void Start () {
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time > fireRate) {
            
            if (Input.GetKeyDown("space") && exit_Point.name == "Player1") {
                time = Time.time;
                GameObject bullet_inst = Instantiate(shotPrefab, exit_Point.transform.position, Quaternion.identity);
                bullet_inst.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.right * speed);
            }
            else if (Input.GetKeyDown("[0]") && exit_Point.name == "Player2") {
                time = Time.time;
                GameObject bullet_inst = Instantiate(shotPrefab, exit_Point.transform.position, Quaternion.identity);
                bullet_inst.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.right * speed);
            }
        }
    }
}


