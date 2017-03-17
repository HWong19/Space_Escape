using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtnManagers : MonoBehaviour {

    public void NewGameBtn(string NewGameLevel) {
        SceneManager.LoadScene(NewGameLevel);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
