using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The parent ZoneBehaviour for both ChoiceZoneBehaviour and TransitionZoneBehaviour.
/// </summary>
public class InteractionZoneBehaviour : MonoBehaviour
{

    protected bool IsPlayerNearby(float radius)
    {
        return ((transform.position - Camera.main.transform.position).magnitude < radius);
    }

    // Create popup with given arguments and return it to be used in the respective zone
    protected GameObject CreatePopup(GameObject popupPrefab, Vector3 popupScale, InteractionZoneBehaviour zoneBehaviour, string prompt)
    {
        Vector3 directionToPlayer = (Camera.main.transform.position - gameObject.transform.position).normalized;
        GameObject createdPopup = Instantiate(popupPrefab, gameObject.transform.position + directionToPlayer, gameObject.transform.rotation);
        createdPopup.transform.localScale = popupScale;

        if (zoneBehaviour.GetType() == typeof(ChoiceZoneBehaviour))
        {
            createdPopup.GetComponent<ChoicePopupBehaviour>().parentZone = (ChoiceZoneBehaviour)zoneBehaviour;
            createdPopup.GetComponent<ChoicePopupBehaviour>().prompt = prompt;
        }

        if (zoneBehaviour.GetType() == typeof(TransitionZoneBehaviour))
        {
            createdPopup.GetComponent<TransitionPopupBehaviour>().parentZone = (TransitionZoneBehaviour)zoneBehaviour;
            createdPopup.GetComponent<TransitionPopupBehaviour>().prompt = prompt;
        }

        return createdPopup;
    }

    protected void DestroyPopup(GameObject popup)
    {
        if (popup)
        {
            Destroy(popup);
        }
    }
}
