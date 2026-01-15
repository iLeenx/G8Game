using UnityEngine;

public class ThirdGameInstruction : MonoBehaviour
{
    public GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void openPanel()
    {
        panel.SetActive(true);
    }
    public void closePanel()
    {
        panel.SetActive(false);
    }
}
