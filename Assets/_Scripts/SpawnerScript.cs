using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public GameObject twoWall;
	public GameObject threeWall;
    public GameObject fourWall;
	public GameObject capsule;
	public GameObject diamond;
	public GameObject doubleV;
	public GameObject xObstacle;

	private float lastObstacleSpawnTime;
	private float restPeriod;

    public float speedUpInterval = 10f;
    private float speedUpTimer = 0f;
    public float speedUpMultiplier = 1.18f;

    public int speedUpMultipleCap = 4;

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
        speedUpTimer += Time.deltaTime;
	}

	void SpawnObstacle(){
		float rng = Random.value;
        GameObject instantiatedObject = null;
        int speedUpTimeMultiple = (int)Mathf.Ceil(speedUpTimer / speedUpInterval);

        if (speedUpTimeMultiple > speedUpMultipleCap)
            speedUpTimeMultiple = speedUpMultipleCap;

		if (rng < 0.5f) {
			InstantiateCapsule (5);
			restPeriod = 5f;
		} else if (rng < 0.6f) {
			instantiatedObject = Instantiate (twoWall, gameObject.transform.position, new Quaternion());
			restPeriod = 3f;
		} else if (rng < 0.68f) {
            instantiatedObject = Instantiate(threeWall, gameObject.transform.position, new Quaternion());
			restPeriod = 3f;
		} else if (rng < 0.78f) {
            instantiatedObject = Instantiate(fourWall, gameObject.transform.position, new Quaternion());
            restPeriod = 3f;
        } else if (rng < 0.86f) {
            instantiatedObject = Instantiate(diamond, gameObject.transform.position, new Quaternion());
			restPeriod = 5f;
		} else if (rng < 0.95f) {
            instantiatedObject = Instantiate(doubleV, gameObject.transform.position, new Quaternion());
			restPeriod = 5f;
		} else {
            instantiatedObject = Instantiate(xObstacle, gameObject.transform.position, new Quaternion());
			restPeriod = 5f;
		}

        if (instantiatedObject) {
            ObstacleMovementScript obsMovement = instantiatedObject.GetComponent<ObstacleMovementScript>();
            obsMovement.speed = obsMovement.speed * (speedUpMultiplier * speedUpTimeMultiple / 1.35f);
        }
		lastObstacleSpawnTime = Time.time;
        restPeriod = restPeriod / ( (speedUpTimeMultiple == 0 ? 1 : speedUpTimeMultiple) * 1.2f );
    }

	void InstantiateCapsule(int num)
	{
		for (int i = 0; i < num; ++i) {
			GameObject item;
			item = Instantiate (capsule, gameObject.transform.position, new Quaternion());
			item.transform.Translate (new Vector3(Random.Range(0,10), Random.Range (-5, 5), 0f));
			item.transform.Rotate (new Vector3 (0f, 0f, Random.Range (0, 355)));

            item.GetComponent<ObstacleMovementScript>().speed *= ((speedUpMultiplier / 1.3f) * speedUpMultiplier);
		}
	}
}
