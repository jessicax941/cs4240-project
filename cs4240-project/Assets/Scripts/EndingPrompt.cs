using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingPrompt : MonoBehaviour
{
    public GameObject prompt;
    public float radius;

    private void Start()
    {
        prompt.SetActive(false);
    }

    private void Update()
    {
        if ((Camera.main.transform.position - transform.position).magnitude < radius)
        {
            prompt.SetActive(true);
            PlaySound();
        }
        else
        {
            prompt.SetActive(false);
        }
    }
    void PlaySound()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource)
        {
            // Debug.Log("playing sound");
            audioSource.Play();
        }
    }

    private void LateUpdate()
    {
        Vector3 newRotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position).eulerAngles;
        newRotation.x = 0;
        newRotation.z = 0;
        transform.rotation = Quaternion.Euler(newRotation);
    }

    public void RestartApp()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
