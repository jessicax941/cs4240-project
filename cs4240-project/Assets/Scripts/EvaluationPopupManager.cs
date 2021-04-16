using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Decides which evaluation popups to show in the evaluation scenes.
/// </summary>
public class EvaluationPopupManager : MonoBehaviour
{
    public List<GameObject> hasExtras = new List<GameObject>();

    private List<GameObject> popups = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Get all the child popup GOs
        foreach (Transform child in transform)
        {
            GameObject popup = child.gameObject;
            popups.Add(popup);
        }

        // Hide all extra objects by default
        foreach (GameObject popupWithExtra in hasExtras)
        {
            popupWithExtra.SetActive(false);
        }

        // Enable popups to appear in scene based on good and bad choices made by player
        GameObject choicesManagerGO = GameObject.FindWithTag("ChoicesManager");
        if (choicesManagerGO)
        {
            ChoicesManager cm = choicesManagerGO.GetComponent<ChoicesManager>();
            List<GoodChoice> goodChoices = cm.GetGoodChoices();
            List<BadChoice> badChoices = cm.GetBadChoices();

            EnablePopups(goodChoices);
            EnablePopups(badChoices);
        }
    }

    // Enable popups for the good choices
    private void EnablePopups(List<GoodChoice> goodChoices)
    {
        foreach (GoodChoice choice in goodChoices)
        {
            string choiceString = ChoiceRepresentation.ToString(choice);
            EnablePopup(choiceString);
        }

        // Map choice of 'no utensils' to DineIn popup
        if (goodChoices.Contains(GoodChoice.NoUtensils))
        {
            GameObject respectivePopup = popups.Find(popup => popup.name.Contains("DineIn"));
            if (respectivePopup)
            {
                respectivePopup.SetActive(true);
            }
        }
    }

    // Enable popups for the bad choices
    private void EnablePopups(List<BadChoice> badChoices)
    {
        foreach (BadChoice choice in badChoices)
        {
            string choiceString = ChoiceRepresentation.ToString(choice);
            EnablePopup(choiceString);
        }

        // if (badChoices.Contains(BadChoice.Utensils))
        // {
        //     GameObject respectivePopup = popups.Find(popup => popup.name.Contains("Utensils"));
        //     if (respectivePopup)
        //     {
        //         respectivePopup.SetActive(true);
        //     }
        // }
    }

    // Find respective popup for the choice made and enable it
    private void EnablePopup(string choiceString)
    {
        choiceString = choiceString.Replace(" ", string.Empty);
        
        GameObject respectivePopup = popups.Find(popup => popup.name.Contains(choiceString));
        if (respectivePopup)
        {
            respectivePopup.SetActive(true);
            respectivePopup.GetComponent<EvaluationPopup>().SpawnExtraObjectIfAny();
        }
    }
}
