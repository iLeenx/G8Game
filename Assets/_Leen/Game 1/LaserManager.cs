using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject[] lasers;    // 3 lasers
    public GameObject ruby;        // ruby object

    void Start()
    {
        // Check states and update lasers at start
        for (int i = 0; i < lasers.Length; i++)
        {
            if (PuzzleStateManager.IsLaserSolved(i))
                lasers[i].SetActive(false);
            else
                lasers[i].SetActive(true);
        }

        // Enable ruby if all lasers solved
        ruby.GetComponent<Collider>().enabled = PuzzleStateManager.AllLasersSolved();
    }

    public void CheckAllLasers()
    {
        // Turn off ruby collider if all lasers solved
        if (PuzzleStateManager.AllLasersSolved())
        {
            ruby.GetComponent<Collider>().enabled = true;
            Debug.Log("All lasers off! Ruby is collectible.");
        }
    }
}
