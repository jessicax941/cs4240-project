using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//use the method gotoScene() to change scene with fading.
//this manager is singleton and is meant to be globally accessible.

//this script must have SceneFaderAndSceneLoader.cs in the same gameobject to do the fading
public class MySceneManager : MonoBehaviour
{

    public static MySceneManager instance;
    void Awake()
    {
        // Ensure only one instance 
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    //goes to the scene with specified index. With fading animation.
    public void gotoScene(int scene)
    {
        StartCoroutine(ChangeSceneCoroutine(scene));
    }
    //goes to the scene with specified name. With fading animation.
    public void gotoScene(string scene)
    {
        StartCoroutine(ChangeSceneCoroutine(scene));
    }

    private IEnumerator ChangeSceneCoroutine(int sceneToLoad)
    {
        yield return this.GetComponent<SceneFader>().FadeIn();
        SceneManager.LoadScene(sceneToLoad);
        //yield return Fade(FadeDirection.In);
        yield return this.GetComponent<SceneFader>().FadeOut();
    }
    private IEnumerator ChangeSceneCoroutine(string sceneToLoad)
    {
        yield return this.GetComponent<SceneFader>().FadeIn();
        SceneManager.LoadScene(sceneToLoad);
        //yield return Fade(FadeDirection.In);
        yield return this.GetComponent<SceneFader>().FadeOut();
    }



}
