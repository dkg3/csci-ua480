using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A04dkg3
{
    public class MakeBush : MonoBehaviour
    {
        // this script is used with the bush prefab to make the bush object

        // Use this for initialization
        void Start()
        {
            // get the mesh components for the buses and use triangles to make them
            Mesh mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            Vector3[] vertices = new Vector3[300];
            int[] triangles = new int[900];

            // randomly place the triangles around a sphere
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = Random.onUnitSphere;
            for (int j = 0; j < triangles.Length; j++)
                triangles[j] = (int)(Random.value * 299 + 1);
            
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
            for (int i = 0; i < mesh.normals.Length; i++)
            {
                Debug.Log(mesh.normals[i]);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}