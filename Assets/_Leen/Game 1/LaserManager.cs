using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject[] lasers;    // 3 lasers
    public GameObject ruby;        // ruby object
    public GameObject flashlight;  // flashlight object

    void Start()
    {
        // Check states and update lasers at start
        CheckLaserState();
    }

    public void CheckLaserState()
    {
        // Check states and update lasers at start
        for (int i = 0; i < lasers.Length; i++)
        {
            if (PuzzleStateManager.IsLaserSolved(i))
                lasers[i].SetActive(false);
            else
                lasers[i].SetActive(true);
        }

        // --- Flashlight logic ---
        if (!PuzzleStateManager.IsLaserSolved(0))
        {
            // if laser 0 is NOT solved -> flashlight OFF
            flashlight.SetActive(false);
        }
        else if (PuzzleStateManager.IsLaserSolved(0) && !PuzzleStateManager.IsLaserSolved(2))
        {
            // if laser 0 solved AND laser 2 NOT solved -> flashlight ON
            flashlight.SetActive(true);
        }
        else if (PuzzleStateManager.IsLaserSolved(0) && PuzzleStateManager.IsLaserSolved(2))
        {
            // if laser 0 solved AND laser 2 solved -> flashlight OFF again
            flashlight.SetActive(false);
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
