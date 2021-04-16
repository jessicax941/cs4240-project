using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps track of choices made throughout the scenes. Only one instance of ChoicesManager in all the scenes.
/// </summary>
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

    public void ChoseGoodChoice(GoodChoice goodChoice)
    {
        goodChoices.Add(goodChoice);
        HandleSpecialCase();
    }

    public void ChoseBadChoice(BadChoice badChoice)
    {
        if (badChoices.Contains(BadChoice.Takeaway) && badChoice.Equals(BadChoice.Utensils))
        {
            // Don't add 'utensils' bad choice since 'takeaway' is already counted
        }
        else
        {
            badChoices.Add(badChoice);
        }
        HandleSpecialCase();
    }

    private void HandleSpecialCase()
    {
        // Special case of chose takeaway but do not need cutlery
        if (badChoices.Contains(BadChoice.Takeaway) && goodChoices.Contains(GoodChoice.NoUtensils))
        {
            badChoices.Remove(BadChoice.Takeaway);
        }
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
