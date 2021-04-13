using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{

    public static ChoicesManager instance;

    private List<GoodChoice> goodChoices = new List<GoodChoice>();
    private List<BadChoice> badChoices = new List<BadChoice>();

    public List<GoodChoice> GetGoodChoices()
    {
        return goodChoices;
    }

    public List<BadChoice> GetBadChoices()
    {
        return badChoices;
    }

    void Awake()
    {
        Debug.Log("awake");
        Debug.Log("goodChoices: " + goodChoices.Count);
        Debug.Log("badChoices: " + badChoices.Count);
        // for testing purposes
        goodChoices.Add(GoodChoice.Chicken);
        goodChoices.Add(GoodChoice.DineIn);
        goodChoices.Add(GoodChoice.Bag);
        goodChoices.Add(GoodChoice.NoUtensils);
        badChoices.Add(BadChoice.Takeaway);
        badChoices.Add(BadChoice.Pork);
        badChoices.Add(BadChoice.PlasticBag);
        badChoices.Add(BadChoice.Utensils);

        // Ensure only one instance of ChoicesManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start() {

    }

    public void ChoseGoodChoice(GoodChoice goodChoice)
    {
        goodChoices.Add(goodChoice);
    }

    public void ChoseBadChoice(BadChoice badChoice)
    {
        badChoices.Add(badChoice);
    }

    public string GetFinalSceneName()
    {
        if (goodChoices.Count > badChoices.Count)
        {
            return "EvaluationScene_Good";
        }
        else
        {
            return "EvaluationScene_Bad";
        }
    }
}
