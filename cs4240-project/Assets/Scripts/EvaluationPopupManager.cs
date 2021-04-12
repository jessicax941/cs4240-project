using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationPopupManager : MonoBehaviour
{
    public GameObject evaluationPopup;

    private List<GameObject> popups = new List<GameObject>(); // all disabled by default


    // Start is called before the first frame update
    void Start()
    {
        // get all the child popup GOs
        foreach (Transform child in transform) {
            popups.Add(child.gameObject);
            child.gameObject.SetActive(false);
            Debug.Log("popup: " + child.GetComponent<EvaluationPopup>().GetTitle());
        }

        // enable popups to appear in scene based on good and bad choices made by player
        GameObject choicesManagerGO = GameObject.FindWithTag("ChoicesManager");
        if (choicesManagerGO) {
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
            EnablePopup(choiceString);
        }
    }

    private void EnablePopups(List<BadChoice> badChoices)
    {
        foreach (BadChoice choice in badChoices)
        {
            string choiceString = ChoiceRepresentation.ToString(choice);
            EnablePopup(choiceString);
        }
    }

    private void EnablePopup(string choice)
    {
        GameObject respectivePopup = popups.Find(popup => popup.GetComponent<EvaluationPopup>().GetTitle().Equals(choice));
        if (respectivePopup)
        {
            respectivePopup.SetActive(true);
        } 
        else
        {
            Debug.Log("did not find popup");
        }
    }
}
