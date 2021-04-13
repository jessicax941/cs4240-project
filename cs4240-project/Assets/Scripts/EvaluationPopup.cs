using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationPopup : MonoBehaviour
{
    public float radius = 2f;
    public GameObject contents;
    public Text title;

    [Header("Extra Object to Spawn (optional)")]
    public GameObject objectToSpawn;
    public float Yposition;
    public Vector3 rotation;

    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        if (objectToSpawn)
        {
            objectToSpawn.SetActive(false);   
        }
    }

    public void ShowExtraObjectIfAny()
    {
        if (objectToSpawn)
        {
            objectToSpawn.SetActive(true);
        }
        // for more dynamic scenes
        if (objectToSpawn && !spawnedObject)
        {
            // only spawn object if there is an object to spawn and if it has not been spawned yet
            // Vector3 objectPosition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            spawnedObject = Instantiate(objectToSpawn, new Vector3(transform.position.x, Yposition, transform.position.z), Quaternion.identity, transform.parent);
            if (spawnedObject) {
                spawnedObject.transform.Rotate(rotation, Space.World);
                spawnedObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!contents.activeSelf && IsPlayerNearby(radius))
        {
            Debug.Log("enabling " + title.text);
            contents.SetActive(true);
        }
        else if (contents.activeSelf && !IsPlayerNearby(radius))
        {
            Debug.Log("disabling " + title.text);
            contents.SetActive(false);
        }
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }

    bool IsPlayerNearby(float radius)
    {
        return ((transform.position - Camera.main.transform.position).magnitude < radius);
    }

    public string GetTitle()
    {
        return title.text;
    }

}
