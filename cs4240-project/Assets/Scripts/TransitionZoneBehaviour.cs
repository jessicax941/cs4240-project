using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionZoneBehaviour : AbstractZoneBehaviour
{
    public GameObject popupPrefab;
    public string text;
    public float radius;
    public Vector3 popupScale;
    public string newSceneName;

    private GameObject popup;
    private TransitionZoneBehaviour selfZoneBehaviour;

    void Start()
    {
        selfZoneBehaviour = gameObject.GetComponent<TransitionZoneBehaviour>();
    }

    void Update()
    {
        if (!popup && IsPlayerNearby())
        {
            CreatePopup();
        }
        else if (popup && !IsPlayerNearby())
        {
            DestroyPopup();
        }
    }

    private bool IsPlayerNearby()
    {
        return ((transform.position - Camera.main.transform.position).magnitude < radius);
    }

    private void CreatePopup()
    {
        if (!popup)
        {
            Vector3 directionToPlayer = (Camera.main.transform.position - gameObject.transform.position).normalized;
            popup = Instantiate(popupPrefab, gameObject.transform.position + gameObject.transform.up + directionToPlayer, gameObject.transform.rotation);
            popup.transform.localScale = popupScale;
            popup.GetComponent<PopupBehaviour>().parentZone = selfZoneBehaviour;
            popup.GetComponent<PopupBehaviour>().textString = "Would you like to move to " + text;
        }
    }

    private void DestroyPopup()
    {
        if (popup)
        {
            Destroy(popup);
        }
    }

    public override void YesPressed()
    {
        StartCoroutine(LoadNextScene());
    }

    public override void NoPressed()
    {
        // Do nothing
    }

    private IEnumerator LoadNextScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newSceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
