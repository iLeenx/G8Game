using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject[] lasers;
    public GameObject ruby;

    private int disabledLasers = 0;

    public void DisableLaser(int index)
    {
        if (index < 0 || index >= lasers.Length) return;

        lasers[index].SetActive(false);
        disabledLasers++;

        Debug.Log("Laser " + index + " disabled!");

        if (disabledLasers == lasers.Length)
        {
            Debug.Log("ALL LASERS OFF! You can steal the ruby!");
            EnableRubyPickup();
        }
    }

    void EnableRubyPickup()
    {
        // allow player to pick up the ruby
        ruby.GetComponent<Collider>().enabled = true;
        // or show UI text like "Press E to take ruby"
    }
}
