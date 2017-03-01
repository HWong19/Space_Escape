using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public GameObject twoWall;
	public GameObject threeWall;
	public GameObject capsule;
	public GameObject diamond;
	public GameObject doubleV;
	public GameObject xObstacle;


	private float lastObstacleSpawnTime;
	private float restPeriod;
	// Use this for initialization
	void Start () {
		lastObstacleSpawnTime = 0f;
		restPeriod = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastObstacleSpawnTime > restPeriod) {
			SpawnObstacle ();
		}
	}

	void SpawnObstacle(){
		float rng = Random.value;

		if (rng < 0.5f) {
			InstantiateCapsule (5);
			restPeriod = 5f;
		} else if (rng < 0.6f) {
			Instantiate (twoWall, gameObject.transform.position, new Quaternion());
			restPeriod = 3f;
		} else if (rng < 0.7f) {
			Instantiate (threeWall, gameObject.transform.position, new Quaternion());
			restPeriod = 3f;
		} else if (rng < 0.8f) {
			Instantiate (diamond, gameObject.transform.position, new Quaternion());
			restPeriod = 5f;
		} else if (rng < 0.9f) {
			Instantiate (doubleV, gameObject.transform.position, new Quaternion());
			restPeriod = 5f;
		} else {
			Instantiate (xObstacle, gameObject.transform.position, new Quaternion());
			restPeriod = 5f;
		}

		lastObstacleSpawnTime = Time.time;
	}

	void InstantiateCapsule(int num)
	{
		for (int i = 0; i < num; ++i) {
			GameObject item;
			item = Instantiate (capsule, gameObject.transform.position, new Quaternion());
			item.transform.Translate (new Vector3(Random.Range(0,10), Random.Range (-5, 5), 0f));
			item.transform.Rotate (new Vector3 (0f, 0f, Random.Range (0, 355)));
		}
	}
}
