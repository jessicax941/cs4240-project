using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject startMenuPanel;
    public List<string> introTitles;
    public List<string> introTexts;

    private int introIndex;
    private int numIntroPanels;
    private Text introTitle;
    private Text introText;
    private Text nextButtonText;

    private void Start()
    {
        introIndex = 0;
        numIntroPanels = introTitles.Count - 1;
        introTitle = transform.Find("Intro/IntroTitle").GetComponent<Text>();
        introText = transform.Find("Intro/IntroText").GetComponent<Text>();
        nextButtonText = transform.Find("Intro/NextButton/NextText").GetComponent<Text>();
        introPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }

    public void StartApp()
    {
        Debug.Log("Start");
        StartIntro();
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

    private void StartIntro()
    {
        introPanel.SetActive(true);
        startMenuPanel.SetActive(false);
        UpdateTitle();
        UpdateText();
    }

    public void BackPressed()
    {
        if (introIndex == 0)
        {
            introPanel.SetActive(false);
            startMenuPanel.SetActive(true);
        }
        else
        {
            introIndex--;
            UpdateTitle();
            UpdateText();
        }

        nextButtonText.text = "Next";
    }

    public void NextPressed()
    {
        if (introIndex == numIntroPanels)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            introIndex++;
            UpdateTitle();
            UpdateText();
        }

        if (introIndex == numIntroPanels)
        {
            nextButtonText.text = "Begin";
        }
    }

    private void UpdateTitle()
    {
        introTitle.text = introTitles[introIndex];
    }

    private void UpdateText()
    {
        introText.text = introTexts[introIndex];
    }
}

