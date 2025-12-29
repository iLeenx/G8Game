using UnityEngine;
using System.Collections;

public class ShowUIAfterDelay : MonoBehaviour
{
    public GameObject uiObject; // the UI you want to show
    public float delay = 6f;    // time before showing

    void Start()
    {
        uiObject.SetActive(false); // hide at start
        StartCoroutine(ShowAfterTime());
    }

    IEnumerator ShowAfterTime()
    {
        yield return new WaitForSeconds(delay);
        uiObject.SetActive(true); // show after 6 seconds
    }
}
