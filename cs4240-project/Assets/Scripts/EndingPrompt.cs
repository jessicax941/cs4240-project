using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Displayed in the evaluation scenes to allow player to return to the main menu.
/// </summary>
public class EndingPrompt : MonoBehaviour
{
    public GameObject prompt;
    public GameObject exclamationMark;
    public float radius;

    private void Start()
    {
        prompt.SetActive(false);
    }

    private void Update()
    {
        // Show prompt only when player is nearby
        if ((Camera.main.transform.position - transform.position).magnitude < radius)
        {
            prompt.SetActive(true);
            exclamationMark.SetActive(false);
            PlaySound();
        }
        else
        {
            prompt.SetActive(false);
            exclamationMark.SetActive(true);
        }
    }
    void PlaySound()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.Play();
        }
    }

    private void LateUpdate()
    {
        // Rotate the prompt to follow the player's camera
        Vector3 newRotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position).eulerAngles;
        newRotation.x = 0;
        newRotation.z = 0;
        transform.rotation = Quaternion.Euler(newRotation);
    }

    public void RestartApp()
    {
        SceneManager.LoadScene(0);
    }

}
