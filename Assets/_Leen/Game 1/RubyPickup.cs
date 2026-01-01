using UnityEngine;
using System.Collections;

public class RubyPickup : MonoBehaviour
{
    public bool canPickUp = false;
    public GameObject pickUpPanel;
    public GameObject rubyInHand = null;
    public GameObject escapePanel;

    public VoiceLine RubyStolenLine;
    public VoiceLine pickUpLine;

    public VoiceManager voiceManager;

    private void Start()
    {
        if (voiceManager == null)
        {
            voiceManager = FindFirstObjectByType<VoiceManager>();
        }

        pickUpPanel.SetActive(false);
        rubyInHand.SetActive(false);
        escapePanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
            canPickUp = true;
            pickUpPanel.SetActive(true);

        StartCoroutine(PlaySequence1());


    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
            canPickUp = false;
            pickUpPanel.SetActive(true);
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Ruby Stolen!");

            StartCoroutine(PlaySequence2());

            if (rubyInHand != null)
            {
                rubyInHand.SetActive(true);
                pickUpPanel.SetActive(false);
                escapePanel.SetActive(true);

                //Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;

            }

            Destroy(gameObject); // or start cutscene
        }
    }

    IEnumerator PlaySequence1()
    {
        yield return new WaitForSeconds(2f);

        // play first line
        voiceManager.PlayVoice(RubyStolenLine);

        // wait for that audio to finish + 3 seconds
        yield return new WaitForSeconds(voiceManager.audioSource.clip.length + 3f);

        //// play next line
        //voiceManager.PlayVoice(doorTutorialLine);
    }
    IEnumerator PlaySequence2()
    {
        yield return new WaitForSeconds(2f);

        // play first line
        voiceManager.PlayVoice(pickUpLine);

        // wait for that audio to finish + 3 seconds
        yield return new WaitForSeconds(voiceManager.audioSource.clip.length + 3f);

        //// play next line
        //voiceManager.PlayVoice(doorTutorialLine);
    }
}
