using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Popup that gives player two options, one good choice (more environmentally-friendly),
/// and one bad choice (less environmentally-friendly).
/// </summary>
public class ChoicePopupBehaviour : MonoBehaviour
{
    public ChoiceZoneBehaviour parentZone;
    public string prompt;
    public Text promptText;
    public Button goodChoiceButton;
    public Text goodChoiceText;
    public Button badChoiceButton;
    public Text badChoiceText;

    private void Start()
    {
        promptText.text = prompt;

        goodChoiceButton.onClick.AddListener(() => { parentZone.ChoseGoodChoice(); });
        goodChoiceText.text = ChoiceRepresentation.ToString(parentZone.goodChoice);

        badChoiceButton.onClick.AddListener(() => { parentZone.ChoseBadChoice(); });
        badChoiceText.text = ChoiceRepresentation.ToString(parentZone.badChoice);
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }
}
