using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool gameOver = false;
    public int lost;
    public GameObject red_won;
    public GameObject blue_won;
    public static GameController instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (gameOver == true) {
            Time.timeScale = 0;
            if (lost == 1) {
                blue_won.SetActive(true);
            }
            else if (lost == 2) {
                red_won.SetActive(true);
            }
        }
    }
}
