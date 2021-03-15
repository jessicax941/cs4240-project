using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZoneBehaviour : MonoBehaviour
{
    public GameObject canvasPrefab;
    public int numChoices;
    public List<string> choices;

    private int currChoice;
    private GameObject popup;

    void Start()
    {
        currChoice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createPopup()
    {
        popup = Instantiate(canvasPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }

    public void destroyPopup()
    {
        Destroy(popup);
    }
}
