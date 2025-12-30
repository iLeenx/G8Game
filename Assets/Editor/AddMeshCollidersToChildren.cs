using UnityEngine;
using UnityEditor;

public class AddMeshCollidersToChildren
{
    [MenuItem("Tools/Add Mesh Colliders To Selected")]
    static void AddMeshColliders()
    {
        foreach (GameObject parent in Selection.gameObjects)
        {
            MeshFilter[] meshFilters = parent.GetComponentsInChildren<MeshFilter>();

            foreach (MeshFilter mf in meshFilters)
            {
                if (mf.GetComponent<MeshCollider>() == null)
                {
                    MeshCollider mc = mf.gameObject.AddComponent<MeshCollider>();
                    mc.sharedMesh = mf.sharedMesh;
                }
            }
        }
    }
}
