using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Popup that shows up when the player first enters the Foodcourt or Supermarket
/// to give some context as to why the player is there.
/// </summary>
public class IntroPopup : MonoBehaviour
{
    public float timeToLive = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }
}
