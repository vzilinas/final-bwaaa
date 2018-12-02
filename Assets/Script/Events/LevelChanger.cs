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
        // Press the space key to add the Scene additively and move the GameObject to that Scene
        if (previous)
        {
            previous = false;
            m_Scene = previousScene;
            m_MyGameObject = GameObject.Find("Exorcist");
            StartCoroutine(LoadYourAsyncScene());
        }
        else if(next)
        {
            next = false;
            m_Scene = nextScene;
            m_MyGameObject = GameObject.Find("Exorcist");
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

