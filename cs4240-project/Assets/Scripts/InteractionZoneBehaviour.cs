using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZoneBehaviour : AbstractZoneBehaviour
{
    public GameObject popupPrefab;
    public List<string> choices;
    public float radius;
    public Vector3 popupScale;

    private int numChoices;
    private int currChoice;
    private GameObject popup;
    private InteractionZoneBehaviour selfZoneBehaviour;

    void Start()
    {
        numChoices = choices.Count - 1;
        currChoice = 0;
        selfZoneBehaviour = gameObject.GetComponent<InteractionZoneBehaviour>();
    }

    void Update()
    {
        if (!popup && IsPlayerNearby())
        {
            CreatePopup();
        }
        else if (popup && !IsPlayerNearby())
        {
            DestroyPopup();
        }
    }

    private bool IsPlayerNearby()
    {
        return ((transform.position - Camera.main.transform.position).magnitude < radius);
    }

    private void CreatePopup()
    {
        if (!popup)
        {
            Vector3 directionToPlayer = (Camera.main.transform.position - gameObject.transform.position).normalized;
            popup = Instantiate(popupPrefab, gameObject.transform.position + gameObject.transform.up + directionToPlayer, gameObject.transform.rotation);
            popup.transform.localScale = popupScale;
            popup.GetComponent<PopupBehaviour>().parentZone = selfZoneBehaviour;
            popup.GetComponent<PopupBehaviour>().textString = choices[currChoice];
        }
    }

    private void DestroyPopup()
    {
        if (popup)
        {
            Destroy(popup);
        }
    }

    public override void YesPressed()
    {
        if (currChoice < numChoices) {
            currChoice++;
            UpdatePopupText();
        }
    }

    public override void NoPressed()
    {
        if (currChoice < numChoices)
        {
            currChoice++;
            UpdatePopupText();
        }
    }

    private void UpdatePopupText()
    {
        popup.GetComponent<PopupBehaviour>().UpdateText(choices[currChoice]);
    }
}
