using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationPopup : MonoBehaviour
{
    public float radius = 2f;
    public GameObject contents;
    public Text title;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!contents.activeSelf && IsPlayerNearby(radius))
        {
            Debug.Log("enabling " + title.text);
            contents.SetActive(true);
        }
        else if (contents.activeSelf && !IsPlayerNearby(radius))
        {
            Debug.Log("disabling " + title.text);
            contents.SetActive(false);
        }
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }

    bool IsPlayerNearby(float radius)
    {
        return ((transform.position - Camera.main.transform.position).magnitude < radius);
    }

    public string GetTitle()
    {
        return title.text;
    }

}
