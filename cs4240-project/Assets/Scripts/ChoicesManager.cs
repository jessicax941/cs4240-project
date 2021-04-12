using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{

    public static ChoicesManager instance;

    private int score = 0;
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
        // for testing purposes
        goodChoices.Add(GoodChoice.Chicken);
        goodChoices.Add(GoodChoice.DineIn);
        badChoices.Add(BadChoice.Takeaway);
        badChoices.Add(BadChoice.Pork);

    }

    public void ChoseGoodChoice(GoodChoice goodChoice)
    {
        score++;
        goodChoices.Add(goodChoice);
        Debug.Log("Score: " + score);
    }

    public void ChoseBadChoice(BadChoice badChoice)
    {
        score--;
        badChoices.Add(badChoice);
        Debug.Log("Score: " + score);
    }

    public string GetFinalSceneName()
    {
        if (score >= 0)
        {
            return "EvaluationScene_Good";
        }
        else
        {
            return "EvaluationScene_Bad";
        }
    }
}
