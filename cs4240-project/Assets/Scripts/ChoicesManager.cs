using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{

    public static ChoicesManager instance;

    private int score = 0;

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

    public void IncrementScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public void DecrementScore()
    {
        score--;
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
