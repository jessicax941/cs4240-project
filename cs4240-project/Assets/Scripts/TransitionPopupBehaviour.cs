using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPopupBehaviour : MonoBehaviour
{
    public TransitionZoneBehaviour parentZone;
    public string prompt;

    private Text text;
    private Button yesButton;

    private void Start()
    {
        Transform popupContents = gameObject.transform.Find("TransitionPopupContents");
        text = popupContents.Find("Text").GetComponent<Text>();
        text.text = prompt;

        yesButton = popupContents.Find("YesButton").GetComponent<Button>();
        yesButton.onClick.AddListener(() => { parentZone.TransitionToNextScene(); });
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }

    // public void UpdateText(string newText)
    // {
    //     text.text = newText;
    // }
}
