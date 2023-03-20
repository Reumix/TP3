using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{
    public int dimension;
    public int resolution;

    private Mesh p_mesh;
    private Vector3[] p_vertices;
    private int[] p_triangles;
    private int nb_vertices;
    private int nb_triangles;
    private int[,] p_neighbors;

    // Start is called before the first frame update
    void Start()
    {
        nb_vertices = (resolution + 1) * (resolution + 1);
        nb_triangles = resolution * resolution * 2;

        p_mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = p_mesh;

        p_vertices = new Vector3[nb_vertices];
        p_triangles = new int[nb_triangles * 3];
        p_neighbors = new int[nb_vertices, 8];

        float step = (float)dimension / resolution;

        int vertexIndex = 0;
        for (int z = 0; z <= resolution; z++)
        {
            for (int x = 0; x <= resolution; x++)
            {
                float xPos = x * step - dimension / 2f;
                float zPos = z * step - dimension / 2f;
                p_vertices[vertexIndex] = new Vector3(xPos, 0, zPos);

                int[] neighbors = new int[8];
                neighbors[0] = vertexIndex - resolution - 2;
                neighbors[1] = vertexIndex - resolution - 1;
                neighbors[2] = vertexIndex - resolution;
                neighbors[3] = vertexIndex - 1;
                neighbors[4] = vertexIndex + 1;
                neighbors[5] = vertexIndex + resolution;
                neighbors[6] = vertexIndex + resolution + 1;
                neighbors[7] = vertexIndex + resolution + 2;

                for (int i = 0; i < 8; i++)
                {
                    if (neighbors[i] >= 0 && neighbors[i] < nb_vertices)
                    {
                        p_neighbors[vertexIndex, i] = neighbors[i];
                    }
                }
                vertexIndex++;
            }
        }
        p_mesh.vertices = p_vertices;
       
        int triangleIndex = 0;
        for (int z = 0; z < resolution; z++)
        {
            for (int x = 0; x < resolution; x++)
            {
                int vertex = z * (resolution + 1) + x;

                p_triangles[triangleIndex] = vertex + 1;
                p_triangles[triangleIndex + 1] = vertex;
                p_triangles[triangleIndex + 2] = vertex + resolution + 2;
                p_triangles[triangleIndex + 3] = vertex;
                p_triangles[triangleIndex + 4] = vertex + resolution + 1;
                p_triangles[triangleIndex + 5] = vertex + resolution + 2;

                triangleIndex += 6;
            }
        }
        p_mesh.triangles = p_triangles;

        p_mesh.RecalculateBounds();
        p_mesh.RecalculateNormals();
    }

    public int GetNbVertices()
    {
        return nb_vertices;
    }

    public int GetNbTriangles()
    {
        return nb_triangles;
    }
}