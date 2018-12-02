using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    // Type in the name of the Scene you would like to load in the Inspector
    public string nextScene;
    public string previousScene;

    // Assign your GameObject you want to move Scene in the Inspector
    public GameObject m_MyGameObject;

    public bool previous = false;
    public bool next = false;
    private string m_Scene;
    void Update()
    {
        var rnd = new System.Random();
        var tick = rnd.Next(1, 6);
        m_MyGameObject = GameObject.Find("Exorcist");

        // Press the space key to add the Scene additively and move the GameObject to that Scene
        if (previous)
        {
            if (tick == 1)
            {
                Debug.Log("playerHealthDebuff");
                if (m_MyGameObject.GetComponent<ExorcistController>().currentHealth < 1)
                {
                    BuffManager.playerHealthDebuff = true;
                }
                else
                {
                    tick = 2;
                }
            }
            if (tick == 2)
            {
                Debug.Log("playerMovementDebuff");
                if (!BuffManager.playerMovementDebuff)
                {
                    BuffManager.playerMovementDebuff = true;
                }
                else
                {
                    tick = 3;
                }
            }
            if (tick == 3)
            {
                Debug.Log("monsterMovementBuff");
                if (!BuffManager.monsterMovementBuff)
                {
                    BuffManager.monsterMovementBuff = true;
                }
                else
                {
                    tick = 4;
                }
            }
            if (tick == 4)
            {
                Debug.Log("highscoredebuff");
                if (!BuffManager.highScoreDebuff)
                {
                    BuffManager.highScoreDebuff = true;
                }
                else
                {
                    tick = 4;
                }
            }
            if (tick == 5)
            {
                Debug.Log("visibility");
                if (!BuffManager.visibilityDebuff)
                {
                    BuffManager.visibilityDebuff = true;
                }
                else
                {
                    BuffManager.debuffCounter += 1;
                }
            }
            previous = false;
            m_Scene = previousScene;
            StartCoroutine(LoadYourAsyncScene());
        }
        else if(next)
        {
            next = false;
            m_Scene = nextScene;
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        var scene = SceneManager.GetSceneByName(m_Scene);
        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(m_MyGameObject, scene);
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}

