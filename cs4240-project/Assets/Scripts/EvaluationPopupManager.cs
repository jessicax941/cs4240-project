using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationPopupManager : MonoBehaviour
{
    public GameObject evaluationPopup;

    private List<GameObject> popups = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) {
            Debug.Log(child);
            popups.Add(child.gameObject);
        }
        Debug.Log("popups:" + popups.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
