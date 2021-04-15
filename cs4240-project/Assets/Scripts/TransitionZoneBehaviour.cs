using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Interactable area to allow player to move on to the next scene.
/// </summary>
public class TransitionZoneBehaviour : InteractionZoneBehaviour
{
    public GameObject popupCanvas;
    public string prompt;
    public float radius;
    public Vector3 popupScale;
    public bool isLastScene = false;
    public string nextSceneName;
    public GameObject exclamationMark;

    private GameObject choicesManager;
    private GameObject popupObject;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        choicesManager = GameObject.FindWithTag("ChoicesManager");
    }

    void Update()
    {   
        if (!popupObject && base.IsPlayerNearby(radius))
        {
            popupObject = base.CreatePopup(popupCanvas, popupScale, this, prompt);
            exclamationMark.SetActive(false);
            PlayPopupSound();
        }
        else if (popupObject && !base.IsPlayerNearby(radius))
        {
            DestroyPopup(popupObject);
            exclamationMark.SetActive(true);
        }
    }

    public void TransitionToNextScene()
    {
        if (isLastScene && choicesManager)
        {
            nextSceneName = choicesManager.GetComponent<ChoicesManager>().GetFinalSceneName();
        }

        if (!nextSceneName.Equals(string.Empty))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void PlayPopupSound()
    {
        if (audioSource)
        {
            audioSource.Play();
        }
    }

}
