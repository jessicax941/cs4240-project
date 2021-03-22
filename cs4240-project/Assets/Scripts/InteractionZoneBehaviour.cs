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

    protected void CreatePopup(GameObject popup, GameObject popupPrefab, Vector3 popupScale, InteractionZoneBehaviour zoneBehaviour, string prompt)
    {
        if (!popup)
        {
            Vector3 directionToPlayer = (Camera.main.transform.position - gameObject.transform.position).normalized;
            popup = Instantiate(popupPrefab, gameObject.transform.position + gameObject.transform.up + directionToPlayer, gameObject.transform.rotation);
            popup.transform.localScale = popupScale;
            if (zoneBehaviour.GetType() == typeof(ChoiceZoneBehaviour))
            {
                popup.GetComponent<ChoicePopupBehaviour>().parentZone = (ChoiceZoneBehaviour)zoneBehaviour;
                popup.GetComponent<ChoicePopupBehaviour>().prompt = prompt;
            }
            if (zoneBehaviour.GetType() == typeof(TransitionZoneBehaviour))
            {
                popup.GetComponent<ChoicePopupBehaviour>().parentZone = (TransitionZoneBehaviour)zoneBehaviour;
                popup.GetComponent<ChoicePopupBehaviour>().prompt = prompt;
            }
        }
    }

    protected void DestroyPopup(GameObject popup)
    {
        if (popup)
        {
            Destroy(popup);
        }
    }
}
