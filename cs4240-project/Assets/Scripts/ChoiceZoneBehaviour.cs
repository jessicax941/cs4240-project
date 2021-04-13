using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceZoneBehaviour : InteractionZoneBehaviour
{
    public GameObject popupCanvas;
    public List<string> choices;
    public float radius;
    public Vector3 popupScale;
    public string prompt;
    public GoodChoice goodChoice;
    public BadChoice badChoice;

    private GameObject choicesManager;
    private int numChoices;
    // private int currChoice;
    private GameObject popupObject;
    private GameObject exclamationMark;
    private bool hasSelected;

    void Start()
    {
        numChoices = choices.Count - 1;
        // currChoice = 0;
        choicesManager = GameObject.FindWithTag("ChoicesManager");
        GameObject childObject = transform.GetChild(0).gameObject;
        if (childObject)
        {
            exclamationMark = childObject;
        }
    }

    void Update()
    {
        if (!hasSelected)
        {
            if (!popupObject && base.IsPlayerNearby(radius))
            {
                popupObject = base.CreatePopup(popupCanvas, popupScale, this, prompt);
            }
            if (popupObject && !base.IsPlayerNearby(radius))
            {
                DestroyPopup(popupObject);
            }
        }
        
    }
    public void ChoseGoodChoice()
    {
        if (choicesManager)
        {
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
        if (popupObject)
        {
            Destroy(popupObject);
        }
    }

}
