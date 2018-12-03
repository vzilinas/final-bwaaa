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
        GameObject.Find("Exorcist").GetComponent<ExorcistController>().alreadyPaused = false;
        UnloadScene(sceneName);
    }

    public void EndGame(string sceneName)
    {
        Debug.Log(sceneName + " - entered EndGame");
        var exorcist = GameObject.Find("Exorcist");
        Destroy(exorcist);
        BuffManager.visibilityDebuff = false;
        BuffManager.highScoreDebuff = false; //
        BuffManager.playerHealthDebuff = false; //
        BuffManager.playerMovementDebuff = false; //
        BuffManager.monsterMovementBuff = false; //

        BuffManager.highScoreBuff = false; //
        BuffManager.movementBuff = false; //
        BuffManager.healthBuff = false;
        BuffManager.fireRateBuff = false;

        BuffManager.buffCounter = 0;
        BuffManager.debuffCounter = 0;
        BuffDebuff.effects.Clear();
        LoadScene(sceneName);
    }
}
