using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc_Pause : MonoBehaviour {

    [SerializeField]
    private GameObject Main_Menu;

	private bool screen_paused = false;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape") && screen_paused == false) {
            Time.timeScale = 0;
            Main_Menu.SetActive(true);
            screen_paused = true;
            
        }
        else if(Input.GetKeyDown("escape") && screen_paused == true) {
            Time.timeScale = 1;
            Main_Menu.SetActive(false);
            screen_paused = false;
        }
	}
}
