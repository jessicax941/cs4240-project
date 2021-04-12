using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{

    public static ChoicesManager instance;

    private int score = 0;
    private List<string> goodChoices = new List<string>();
    private List<string> badChoices = new List<string>();

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

    public void ChoseGoodChoice(string goodChoice)
    {
        score++;
        goodChoices.Add(goodChoice);
        Debug.Log("Score: " + score);
    }

    public void ChoseBadChoice(string badChoice)
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
