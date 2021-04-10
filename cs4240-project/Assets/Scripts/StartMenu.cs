using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartApp()
    {
        Debug.Log("Start");
        GameObject.FindObjectOfType<MySceneManager>().gotoScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenSettings()
    {
        Debug.Log("Settings");
    }

    public void QuitApp()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

}

