using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject introPanel;
    public GameObject startMenuPanel;
    private string[] introTitles;
    private string[] introTexts;

    private int introIndex;
    private int numIntroPanels;
    private Text introTitle;
    private Text introText;
    private Text nextButtonText;

    private void Start()
    {
        introIndex = 0;
        introTitle = transform.Find("Intro/IntroTitle").GetComponent<Text>();
        introText = transform.Find("Intro/IntroText").GetComponent<Text>();
        nextButtonText = transform.Find("Intro/NextButton/NextText").GetComponent<Text>();
        introPanel.SetActive(false);
        startMenuPanel.SetActive(true);

        numIntroPanels = 3;
        introTitles = new string[numIntroPanels + 1];
        introTitles[0] = "Welcome to Ecoverse!";
        introTitles[1] = "How to play";
        introTitles[2] = "Controls";
        introTitles[3] = "That's all!";
        introTexts = new string[numIntroPanels + 1];
        introTexts[0] = "Ecoverse is a VR simulation that aims to teach you how your actions can affect the environment.";
        introTexts[1] = "You will have to traverse a few different locations, and make choices at each location that will affect the ending you receive.";
        introTexts[2] = "Thumb Trackpad (either hand):\nTeleport\nTrigger Button (either hand):\nClick Button";
        introTexts[3] = "We hope you enjoy the game!\nThe future lies in your hands... (literally)";
    }

    public void StartApp()
    {
        StartIntro();
    }

    public void QuitApp()
    {
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

