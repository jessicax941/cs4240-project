using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationPopupManager : MonoBehaviour
{
    public List<GameObject> alwaysEnable = new List<GameObject>(); 
    private List<GameObject> popups = new List<GameObject>(); // all disabled by default

    // Start is called before the first frame update
    void Start()
    {
        // get all the child popup GOs
        foreach (Transform child in transform)
        {
            GameObject popup = child.gameObject;
            if (alwaysEnable.Contains(popup))
            {
                popup.SetActive(true);
            }
            // else
            // {
            //     popups.Add(popup);
            //     popup.SetActive(false);
            // }
        }

        // enable popups to appear in scene based on good and bad choices made by player
        GameObject choicesManagerGO = GameObject.FindWithTag("ChoicesManager");
        if (choicesManagerGO)
        {
            Debug.Log("found cm");
            ChoicesManager cm = choicesManagerGO.GetComponent<ChoicesManager>();
            List<GoodChoice> goodChoices = cm.GetGoodChoices();
            List<BadChoice> badChoices = cm.GetBadChoices();

            EnablePopups(goodChoices);            
            EnablePopups(badChoices);
        }
    }

    private void EnablePopups(List<GoodChoice> goodChoices)
    {
        foreach (GoodChoice choice in goodChoices)
        {
            string choiceString = ChoiceRepresentation.ToString(choice);
            Debug.Log("good choice: " + choiceString);
            EnablePopup(choiceString);
        }
    }

    private void EnablePopups(List<BadChoice> badChoices)
    {
        foreach (BadChoice choice in badChoices)
        {
            string choiceString = ChoiceRepresentation.ToString(choice);
            Debug.Log("bad choice: " + choiceString);
            EnablePopup(choiceString);
        }
    }

    private void EnablePopup(string choiceString)
    {
        choiceString = choiceString.Replace(" ", string.Empty);
        GameObject respectivePopup = popups.Find(popup => popup.name.Contains(choiceString));
        if (respectivePopup)
        {
            // Debug.Log("found popup: " + respectivePopup.GetComponent<EvaluationPopup>().GetTitle());
            respectivePopup.SetActive(true);
            respectivePopup.GetComponent<EvaluationPopup>().SpawnExtraObjectIfAny();
        } 
        else
        {
            Debug.Log("did not find popup for " + choiceString);
        }
    }
}
