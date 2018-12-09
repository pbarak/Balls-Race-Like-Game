using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


    public void NewGameBtn()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void EndGame()
    {
        SceneManager.UnloadSceneAsync("MiniGame");

        Application.Quit();
    }
}
