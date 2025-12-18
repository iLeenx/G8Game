using UnityEngine;
using System.Collections.Generic;


public class ReadCube : MonoBehaviour
{
    public Transform tUp;
    public Transform tDown;
    public Transform tLeft;
    public Transform tRight;
    public Transform tFront;
    public Transform tBack;

    private int layerMask = 1 << 6; // Layer 6 is assigned to "Faces"
    private CubeState cubeState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeState = FindFirstObjectByType<CubeState>();
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> facesHit = new List<GameObject>();
        Vector3 ray = tFront.transform.position;
        RaycastHit hit;

        // does the ray intersect with any objects in the "Faces" layer?
        if (Physics.Raycast(ray, tFront.right, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(ray, tFront.right * hit.distance, Color.yellow);
            facesHit.Add(hit.collider.gameObject);
            Debug.Log("Front Face Hit: " + hit.collider.gameObject.name);
        }
        else
        {
            Debug.DrawRay(ray, tFront.right * 1000, Color.red);
            Debug.Log("Front Face: No hit");
        }
        cubeState.front = facesHit;
    }
}
