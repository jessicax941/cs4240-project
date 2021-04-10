using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TransitionZoneBehaviour : InteractionZoneBehaviour
{
    public GameObject popupCanvas;
    public string prompt;
    public float radius;
    public Vector3 popupScale;
    public bool isLastScene = false;
    public string nextSceneName;

    private GameObject choicesManager;

    private GameObject popupObject;
    // private TransitionZoneBehaviour selfZoneBehaviour;

    void Start()
    {
        choicesManager = GameObject.Find("ChoicesManager");
        // selfZoneBehaviour = gameObject.GetComponent<TransitionZoneBehaviour>();
    }

    void Update()
    {
        if (!popupObject && base.IsPlayerNearby(radius))
        {
            popupObject = base.CreatePopup(popupCanvas, popupScale, this, prompt);
        }
        else if (popupObject && !base.IsPlayerNearby(radius))
        {
            DestroyPopup(popupObject);
        }
    }

    public void TransitionToNextScene()
    {
        Debug.Log("Transition to next scene");

        if (isLastScene && choicesManager)
        {

            nextSceneName = choicesManager.GetComponent<ChoicesManager>().GetFinalSceneName();
        }

        if (nextSceneName == "")
        {
            Debug.LogWarning("nextSceneName is empty!");
            return;
        }

        GameObject.FindObjectOfType<MySceneManager>().gotoScene(nextSceneName);
        // StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        Debug.Log("Loading next scene");
        if (nextSceneName != "")
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }

    // void Update()
    // {
    //     if (!popup && IsPlayerNearby())
    //     {
    //         CreatePopup();
    //     }
    //     else if (popup && !IsPlayerNearby())
    //     {
    //         DestroyPopup();
    //     }
    // }

    // private bool IsPlayerNearby()
    // {
    //     return ((transform.position - Camera.main.transform.position).magnitude < radius);
    // }

    // private void CreatePopup()
    // {
    //     if (!popup)
    //     {
    //         Vector3 directionToPlayer = (Camera.main.transform.position - gameObject.transform.position).normalized;
    //         popup = Instantiate(popupPrefab, gameObject.transform.position + gameObject.transform.up + directionToPlayer, gameObject.transform.rotation);
    //         popup.transform.localScale = popupScale;
    //         popup.GetComponent<PopupBehaviour>().parentZone = selfZoneBehaviour;
    //         popup.GetComponent<PopupBehaviour>().textString = "Would you like to move to " + text;
    //     }
    // }

    // private void DestroyPopup()
    // {
    //     if (popup)
    //     {
    //         Destroy(popup);
    //     }
    // }

    // public override void YesPressed()
    // {
    //     StartCoroutine(LoadNextScene());
    // }

    // public override void NoPressed()
    // {
    //     // Do nothing
    // }

}
