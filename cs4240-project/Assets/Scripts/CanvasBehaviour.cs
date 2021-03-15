using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject playerCamera;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - leftHand.transform.position;
    }

    void LateUpdate()
    {
        transform.position = leftHand.transform.position + offset;
        transform.LookAt(2 * transform.position - playerCamera.transform.position, Vector3.up);
    }
}
