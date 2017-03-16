using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool gameOver = false;
    public int lost;
    public GameObject red_won;
    public GameObject blue_won;
    public static GameController instance;
    public AudioClip P1_won;
    public AudioClip P2_won;
    AudioSource gameOverSound;
    private bool soundPlayed;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
        gameOverSound = GetComponent<AudioSource>();
    }

    void Start() {
        soundPlayed = true;
    }

    void Update() {
        if (gameOver == true) {
            if (lost == 1) {
                blue_won.SetActive(true);
                if (soundPlayed) {
                    gameOverSound.PlayOneShot(P2_won, 1f);
                    soundPlayed = false;
                }
            }
            else if (lost == 2) {
                red_won.SetActive(true);
                if (soundPlayed) {
                    gameOverSound.PlayOneShot(P1_won, 1f);
                    soundPlayed = false;
                }
            }
            Time.timeScale = 0;
        }
    }
}
