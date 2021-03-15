using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    //public GameObject leftHand;
    public GameObject playerCamera;

    private Canvas canvas;
    private bool activeState;

    private void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        activeState = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            activeState = !activeState;
            canvas.enabled = activeState;
        }
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - playerCamera.transform.position, Vector3.up);
    }
}
