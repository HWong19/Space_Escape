using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour {

    public GameObject[] powerUps;
    private int length;

    private float lastObstacleSpawnTime;
    private float restPeriod;
    // Use this for initialization
    void Start() {
        lastObstacleSpawnTime = 0f;
        restPeriod = 0f;

        length = powerUps.Length;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time - lastObstacleSpawnTime > restPeriod) {
            SpawnObstacle();
        }
    }

    void SpawnObstacle() {
        int rng = Random.Range(0, length);

        //if (rng < 0.5f) {
        //    restPeriod = 5f;
        //}
        //else if (rng < 0.6f) {
        float verticalOffset = Random.Range(-1f, 1f) * (Camera.main.orthographicSize - 1);
        print(verticalOffset);
            Instantiate(powerUps[rng], gameObject.transform.position + new Vector3(0, verticalOffset, 0), new Quaternion());
            restPeriod = Random.Range(0.5f, 1);
        //} else {
        //    restPeriod = 5f;
        //}

        lastObstacleSpawnTime = Time.time;
    }

}
