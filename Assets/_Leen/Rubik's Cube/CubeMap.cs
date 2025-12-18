using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class CubeMap : MonoBehaviour
{
    CubeState cubeState;

    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set()
    {
        cubeState = FindFirstObjectByType<CubeState>();

        UpdateMap(cubeState.front, front);
        //UpdateMap(cubeState.back, back);
        //UpdateMap(cubeState.up, up);
        //UpdateMap(cubeState.down, down);
        //UpdateMap(cubeState.left, left);
        //UpdateMap(cubeState.right, right);

    }

    void UpdateMap(List<GameObject> face, Transform side)
    {
        //if (face == null || face.Count == 0)
        //{
        //    Debug.LogWarning("UpdateMap called with empty face list");
        //    return;
        //}

        //int count = Mathf.Min(face.Count, side.childCount);

        //for (int i = 0; i < count; i++)
        //{
        //    var map = side.GetChild(i);
        //    var fName = face[i].name;

        //    if (fName[0] == 'F') map.GetComponent<Image>().color = new Color(1, 0.5f, 0);
        //    //if (fName[0] == 'B') map.GetComponent<Image>().color = Color.red;
        //    //if (fName[0] == 'U') map.GetComponent<Image>().color = Color.yellow;
        //    //if (fName[0] == 'D') map.GetComponent<Image>().color = Color.white;
        //    //if (fName[0] == 'L') map.GetComponent<Image>().color = Color.blue;
        //    //if (fName[0] == 'R') map.GetComponent<Image>().color = Color.green;
        //}


        int i = 0;
        foreach (Transform map in side)
        {
            if (face[0].name[0] == 'F')
            {
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0); // Orange
            }
            //if (face[i].name[0] == 'B')
            //{
            //    map.GetComponent<Image>().color = Color.red;
            //}
            //if (face[i].name[0] == 'U')
            //{
            //    map.GetComponent<Image>().color = Color.yellow;
            //}
            //if (face[i].name[0] == 'D')
            //{
            //    map.GetComponent<Image>().color = Color.white;
            //}
            //if (face[i].name[0] == 'L')
            //{
            //    map.GetComponent<Image>().color = Color.blue;
            //}
            //if (face[i].name[0] == 'R')
            //{
            //    map.GetComponent<Image>().color = Color.green;
            //}

            i++; // increment index to access next face in the list
        }


    }
}
