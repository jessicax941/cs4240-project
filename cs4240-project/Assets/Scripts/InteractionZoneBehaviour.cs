using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZoneBehaviour : MonoBehaviour
{
    // public abstract void ChoseGoodChoice();
    // public abstract void ChoseBadChoice();
    // public abstract void YesPressed();
    // public abstract void NoPressed();

    // void Update()
    // {
    //     if (!popup && IsPlayerNearby())
    //     {
    //         CreatePopup();
    //     }
    //     else if (popup && !IsPlayerNearby())
    //     {
    //         DestroyPopup();
    //     }
    // }

    protected bool IsPlayerNearby(float radius)
    {
        return ((transform.position - Camera.main.transform.position).magnitude < radius);
    }

    protected GameObject CreatePopup(GameObject popupPrefab, Vector3 popupScale, InteractionZoneBehaviour zoneBehaviour, string prompt)
    {
        Vector3 directionToPlayer = (Camera.main.transform.position - gameObject.transform.position).normalized;
        GameObject createdPopup = Instantiate(popupPrefab, gameObject.transform.position + gameObject.transform.up + directionToPlayer, gameObject.transform.rotation);
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
