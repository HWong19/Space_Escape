using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementScript : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-speed, 0f, 0f) * Time.deltaTime, Space.World);
		if (transform.position.x < -20f) {
			Destroy (gameObject);
		}
	}
}
