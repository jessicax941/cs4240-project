using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Popup to allow player to move on to the next scene.
/// </summary>
public class TransitionPopupBehaviour : MonoBehaviour
{
    public TransitionZoneBehaviour parentZone;
    public string prompt;
    public Text promptText;
    public Button yesButton;

    private void Start()
    {
        promptText.text = prompt;

        yesButton.onClick.AddListener(() => { parentZone.TransitionToNextScene(); });
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }
    
}
