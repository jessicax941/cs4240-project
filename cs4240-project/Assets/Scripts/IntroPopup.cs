using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPopup : MonoBehaviour
{
    public float timeToLive = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }
}
