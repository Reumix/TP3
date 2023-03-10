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

    // Start is called before the first frame update
    void Start()
    {
        p_mesh = new Mesh();
        //nb_vertices = resolution * resolution;
        //nb_triangles = 2 * (resolution - 1) * (resolution - 1);
        //p_vertices = new Vector3[nb_vertices];
        //p_triangles = new int[nb_triangles];

        nb_vertices = 4;
        nb_triangles = 2;
        p_vertices = new Vector3[nb_vertices];

        p_vertices[0] = new Vector3(0, 0, 0);
        p_vertices[1] = new Vector3(0, 0, 1);
        p_vertices[2] = new Vector3(1, 0, 1);
        p_vertices[3] = new Vector3(1, 0, 0);

        p_triangles = new int[]
        {
            0,1,2,
            0,2,3
        };

        p_mesh.vertices = p_vertices;
        p_mesh.triangles = p_triangles;
        GetComponent<MeshFilter>().mesh = p_mesh;
    }
}
