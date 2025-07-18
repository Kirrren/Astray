using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public bool onGridLoader;

    public void LoadNewScene(string sceneName)
    {
        string originalScene = SceneManager.GetActiveScene().name;
        Debug.Log("Loading new scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene loaded successfully");
        Debug.Log("Unloading previous scene");
        try
        {
            SceneManager.UnloadSceneAsync(originalScene);
            Debug.Log("Previous scene unloaded successfully");
        }
        catch (Exception e)
        {
            Debug.LogError("Previous scene failed to unload\n" + e);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
