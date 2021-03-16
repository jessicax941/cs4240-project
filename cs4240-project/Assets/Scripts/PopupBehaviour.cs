using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBehaviour : MonoBehaviour
{
    public AbstractZoneBehaviour parentZone;
    public string textString;

    private Text text;
    private Button yesButton;
    private Button noButton;

    private void Start()
    {
        var temp = gameObject.transform.Find("PopupContents");
        text = temp.Find("Text").GetComponent<Text>();
        yesButton = temp.Find("YesButton").GetComponent<Button>();
        noButton = temp.Find("NoButton").GetComponent<Button>();
        yesButton.onClick.AddListener(() => { parentZone.YesPressed(); });
        noButton.onClick.AddListener(() => { parentZone.NoPressed(); });
        text.text = textString;
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
