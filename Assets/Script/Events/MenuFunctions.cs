using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

    // Use this for initialization
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadScene(sceneName);
    }

    public void ResumeGame(string sceneName)
    {
        GameObject.Find("GameFlow").GetComponent<ControlGameFlow>().UnpauseGame();
        UnloadScene(sceneName);
    }
}
