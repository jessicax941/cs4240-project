using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicePopupBehaviour : MonoBehaviour
{
    public ChoiceZoneBehaviour parentZone;
    public string prompt;

    private Text promptText;
    private Button goodChoiceButton;
    private Button badChoiceButton;

    private void Start()
    {
        Transform popupContents = gameObject.transform.Find("ChoicePopupContents");
        promptText = popupContents.Find("Text").GetComponent<Text>();
        promptText.text = prompt;

        Transform goodChoiceButton = popupContents.Find("GoodChoiceButton");
        goodChoiceButton.GetComponent<Button>().onClick.AddListener(() => { parentZone.ChoseGoodChoice(); });
        goodChoiceButton.Find("Text").GetComponent<Text>().text = parentZone.goodChoiceText;

        Transform badChoiceButton = popupContents.Find("BadChoiceButton");
        badChoiceButton.GetComponent<Button>().onClick.AddListener(() => { parentZone.ChoseBadChoice(); });
        badChoiceButton.Find("Text").GetComponent<Text>().text = parentZone.badChoiceText;
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }

    public void UpdateText(string newText)
    {
        promptText.text = newText;
    }
}
