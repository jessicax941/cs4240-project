using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicePopupBehaviour : MonoBehaviour
{
    public ChoiceZoneBehaviour parentZone;
    public string prompt;

    private Text text;
    private Button goodChoiceButton;
    private Button badChoiceButton;

    private void Start()
    {
        Transform popupContents = gameObject.transform.Find("PopupContents");
        text = popupContents.Find("Text").GetComponent<Text>();
        goodChoiceButton = popupContents.Find("GoodChoiceButton").GetComponent<Button>();
        badChoiceButton = popupContents.Find("BadChoiceButton").GetComponent<Button>();
        goodChoiceButton.onClick.AddListener(() => { parentZone.ChoseGoodChoice(); });
        badChoiceButton.onClick.AddListener(() => { parentZone.ChoseBadChoice(); });
        text.text = prompt;
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }

    public void UpdateText(string newText)
    {
        text.text = newText;
    }
}
