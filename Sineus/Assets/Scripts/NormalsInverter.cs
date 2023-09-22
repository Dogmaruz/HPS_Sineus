using UnityEngine;

public class NormalsInverter : MonoBehaviour
{
    public GameObject InvertedObject;

    private void Start()
    {
        InvertSphere();
    }

    private void InvertSphere()
    {
        Vector3[] normals = InvertedObject.GetComponent<MeshFilter>().mesh.normals;

        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }

        InvertedObject.GetComponent<MeshFilter>().sharedMesh.normals = normals;

        int[] triangles = InvertedObject.GetComponent<MeshFilter>().sharedMesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }

        InvertedObject.GetComponent<MeshFilter>().sharedMesh.triangles = triangles;
    }
}
