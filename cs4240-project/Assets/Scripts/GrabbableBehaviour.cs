using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabbableBehaviour : MonoBehaviour
{
    public GameObject grabbableDescriptorPrefab;
    public string titleText;
    public string descriptonText;
    public bool grabbed;
    public Vector3 popupScale;

    private GameObject popup;

    void Start()
    {
        grabbed = false;
    }

    void Update()
    {
        if (!popup && grabbed)
        {
            CreatePopup();
        }
        else if (popup && !grabbed)
        {
            DestroyPopup();
        }
    }

    private void CreatePopup()
    {
        if (!popup)
        {
            popup = Instantiate(grabbableDescriptorPrefab, gameObject.transform.position + (Vector3.up * 0.5f), gameObject.transform.rotation); ;
            popup.transform.localScale = popupScale;
            popup.GetComponent<GrabbableDescriptorBehaviour>().titleString = titleText;
            popup.GetComponent<GrabbableDescriptorBehaviour>().descriptionString = descriptonText;
        }
    }

    private void DestroyPopup()
    {
        if (popup)
        {
            Destroy(popup);
        }
    }

    private void LateUpdate()
    {
        if (popup)
        {
            popup.transform.position = gameObject.transform.position + (Vector3.up * 0.5f);
        }
    }
}
