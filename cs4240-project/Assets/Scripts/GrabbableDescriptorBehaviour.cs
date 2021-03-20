using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabbableDescriptorBehaviour : MonoBehaviour
{
    public string titleString;
    public string descriptionString;

    private Text title;
    private Text description;

    void Start()
    {
        var temp = gameObject.transform.Find("Panel");
        title = temp.Find("Title").GetComponent<Text>();
        description = temp.Find("Description").GetComponent<Text>();
        title.text = titleString;
        description.text = descriptionString;
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }
}
