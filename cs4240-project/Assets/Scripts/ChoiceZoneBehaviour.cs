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
    public string goodChoiceText;
    public string badChoiceText;

    private GameObject choicesManager;
    private int numChoices;
    private int currChoice;
    private GameObject popupObject;
    // private InteractionZoneBehaviour selfZoneBehaviour;

    void Start()
    {
        numChoices = choices.Count - 1;
        currChoice = 0;
        choicesManager = GameObject.Find("ChoicesManager");
        // selfZoneBehaviour = gameObject.GetComponent<InteractionZoneBehaviour>();
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
    public void ChoseGoodChoice()
    {
        if (choicesManager)
        {
            choicesManager.GetComponent<ChoicesManager>().ChoseGoodChoice(goodChoiceText);
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
            choicesManager.GetComponent<ChoicesManager>().ChoseBadChoice(badChoiceText);
        }
        else
        {
            Debug.LogWarning("choicesManager is null");
        }
    }

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
    //         popup.GetComponent<PopupBehaviour>().prompt = choices[currChoice];
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
    //     if (currChoice < numChoices)
    //     {
    //         currChoice++;
    //         UpdatePopupText();
    //     }
    // }

    // public override void NoPressed()
    // {
    //     if (currChoice < numChoices)
    //     {
    //         currChoice++;
    //         UpdatePopupText();
    //     }
    // }

    // private void UpdatePopupText()
    // {
    //     popupObject.GetComponent<PopupBehaviour>().UpdateText(choices[currChoice]);
    // }
}
