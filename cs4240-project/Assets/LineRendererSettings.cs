using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineRendererSettings : MonoBehaviour
{

    public int rendererLength = 20;
    public LayerMask layerMask;
    [SerializeField] LineRenderer rend; // should have alignment set to View and Use World Space unchecked
    private Vector3[] points;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();
        points = new Vector3[2];

        // set start point of line renderer to position of gameObject
        points[0] = Vector3.zero; 
        // set end point to some units away from the gameObject (on forward axis)
        points[1] = transform.position + transform.forward * rendererLength;

        if (rend != null) {
            rend.SetPositions(points);
            rend.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AlignLineRenderer(rend);
    }

    private void AlignLineRenderer(LineRenderer rend) {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit, 1000f, layerMask)) {
            // set end point to the raycast hit
            Debug.Log("hit");
            points[1] = transform.position + transform.forward * hit.distance;
        } else {
            // no raycast hit; set to default distance
            Debug.Log("no hit");
            points[1] = transform.position + transform.forward * rendererLength;
        }

        if (rend != null) {
            rend.SetPositions(points);
        }
    }
}
