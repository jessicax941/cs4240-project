using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractionZoneBehaviour interactionZone = other.gameObject.GetComponent<InteractionZoneBehaviour>();
        if (interactionZone)
        {
            Debug.Log("Trigger enter");
            interactionZone.createPopup();
            Debug.Log("popup created");
            References.debug = "popup created";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exit");
        InteractionZoneBehaviour interactionZone = other.gameObject.GetComponent<InteractionZoneBehaviour>();
        if (interactionZone)
        {
            interactionZone.destroyPopup();
            Debug.Log("popup destroyed");
            References.debug = "popup destroyed";
        }
    }
}
