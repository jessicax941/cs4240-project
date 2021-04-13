using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationPopup : MonoBehaviour
{
    public float radius = 2f;
    public GameObject contents;

    [Header("Extra Object to Spawn (optional)")]
    public GameObject objectToSpawn;
    public float Yposition;
    public Vector3 rotation;

    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SpawnExtraObjectIfAny()
    {
        // for more dynamic scenes
        if (objectToSpawn && !spawnedObject)
        {
            // only spawn object if there is an object to spawn and if it has not been spawned yet
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
            contents.SetActive(true);
            PlaySound();
        }
        else if (contents.activeSelf && !IsPlayerNearby(radius))
        {
            contents.SetActive(false);
        }
    }

    void PlaySound()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.Play();
        }
    }

    bool IsPlayerNearby(float radius)
    {
        return ((transform.position - Camera.main.transform.position).magnitude < radius);
    }

    void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position, Vector3.up);
    }

    

}
