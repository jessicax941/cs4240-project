using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceZoneBehaviour : InteractionZoneBehaviour
{
    public GameObject popupCanvas;
    public GameObject utensilsPopup;
    public float radius;
    public Vector3 popupScale;
    public string prompt;
    public GoodChoice goodChoice;
    public BadChoice badChoice;
    public GameObject exclamationMark;

    private GameObject choicesManager;
    private GameObject popupObject;
    private AudioSource audioSource;
    private bool hasSelected;
    // only used for DineInTakeaway popup
    private bool madeGoodChoice;

    void Start()
    {
        choicesManager = GameObject.FindWithTag("ChoicesManager");
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!hasSelected)
        {
            if (!popupObject && base.IsPlayerNearby(radius))
            {
                popupObject = base.CreatePopup(popupCanvas, popupScale, this, prompt);
                exclamationMark.SetActive(false);
                PlayPopupSound();
            }
            if (popupObject && !base.IsPlayerNearby(radius))
            {
                DestroyPopup(popupObject);
                exclamationMark.SetActive(true);
            }
        }
        
    }
    public void ChoseGoodChoice()
    {
        if (choicesManager)
        {
            madeGoodChoice = true;
            MakePopupDisappear();
            choicesManager.GetComponent<ChoicesManager>().ChoseGoodChoice(goodChoice);
        }
        else
        {
            Debug.LogWarning("choicesManager is null");
        }
    }

    public void ChoseBadChoice()
    {
        if (choicesManager)
        {
            madeGoodChoice = false;
            MakePopupDisappear();
            choicesManager.GetComponent<ChoicesManager>().ChoseBadChoice(badChoice);
        }
        else
        {
            Debug.LogWarning("choicesManager is null");
        }
    }

    private void MakePopupDisappear()
    {
        hasSelected = true;
        exclamationMark.SetActive(false);
        if (gameObject.name.Contains("DineInTakeaway"))
        {
            // show popup for utensils based on choice made
            DisplayUtensilsBasedOnChoice();
        }
        if (popupObject)
        {
            Destroy(popupObject);
        }
    }

    private void DisplayUtensilsBasedOnChoice()
    {
        if (!madeGoodChoice)
        {
            // player picked takeaway, ask if utensils needed
            utensilsPopup.SetActive(true);
            utensilsPopup.transform.position = gameObject.transform.position;
            utensilsPopup.transform.rotation = gameObject.transform.rotation;
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
