using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationPopup : MonoBehaviour
{
    public float radius = 2f;
    public GameObject contents;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(contents.activeSelf);
        if (!contents.activeSelf && IsPlayerNearby(radius))
        {
            Debug.Log("enabling");
            contents.SetActive(true);
        }
        else if (contents.activeSelf && !IsPlayerNearby(radius))
        {
            Debug.Log("disabling");
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

}
