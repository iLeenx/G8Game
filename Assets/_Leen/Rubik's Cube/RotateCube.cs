using UnityEngine;

public class RotateCube : MonoBehaviour
{
    private Vector2 firstPressPos;  // Position where the mouse button is first pressed
    private Vector2 secondPressPos;  // Position where the mouse button is released
    private Vector2 currentSwipe;  // Vector representing the swipe direction

    public GameObject target;  // Reference to the cube GameObject
    public float speed = 200f;  // Speed of rotation

    public float rotationSensitivity = 0.4f; // Sensitivity of mouse drag rotation
    private Vector3 previousMousePosition;
    private Vector3 mouseDelta;

    // Start is called once before the first execution
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
        Drag();
    }

    public void Swipe()
    {
        // Detects mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //Debug.Log("First Press Position: " + firstPressPos);
        }

        // Detects mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            // Get the position where the mouse button is clicked
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            // Calculate the swipe direction from click positions to release positions
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            // Normalize the swipe vector to get direction only
            currentSwipe.Normalize();

            // Determine the swipe direction and rotate the cube accordingly            
            if (LeftSwipe(currentSwipe))
            {
                Debug.Log("Left Swipe Detected");
                target.transform.Rotate( 0, 90, 0, Space.World);
            }
            else if (RightSwipe(currentSwipe))
            {
                Debug.Log("Right Swipe Detected");
                target.transform.Rotate( 0, -90, 0, Space.World);
            }
            else if (UpLeftSwipe(currentSwipe))
            {
                Debug.Log("Up-Left Swipe Detected");
                target.transform.Rotate( 90, 0, 0, Space.World);
            }
            else if (UpRightSwipe(currentSwipe))
            {
                Debug.Log("Up-Right Swipe Detected");
                target.transform.Rotate( 0, 0, -90, Space.World);
            }
            else if (DownLeftSwipe(currentSwipe))
            {
                Debug.Log("Down-Left Swipe Detected");
                target.transform.Rotate( 0, 0, 90, Space.World);
            }
            else if (DownRightSwipe(currentSwipe))
            {
                Debug.Log("Down-Right Swipe Detected");
                target.transform.Rotate( -90, 0, 0, Space.World);
            }

        }
    }

    bool LeftSwipe(Vector2 swipe)
    {
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool RightSwipe(Vector2 swipe)
    {
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f;
    }
    bool UpLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y > 0 && currentSwipe.x < 0;
    }
    bool UpRightSwipe(Vector2 swipe) 
    {
        return currentSwipe.y > 0 && currentSwipe.x > 0;
    }
    bool DownLeftSwipe(Vector2 swipe)
    {
        return currentSwipe.y < 0 && currentSwipe.x < 0;
    }
    bool DownRightSwipe(Vector2 swipe) 
    {
        return currentSwipe.y < 0 && currentSwipe.x > 0;
    }

    void _RotateCube()
    {
        // auto-rotate the cube slowly for visual effect
        if (transform.rotation != target.transform.rotation)
        {
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
        }
    }

    void Drag()
    {
        if (Input.GetMouseButton(1))
        {
            // while right mouse button is held down
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= rotationSensitivity; // rotation speed
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else
        {
            _RotateCube();
        }
        previousMousePosition = Input.mousePosition;
    }
}
