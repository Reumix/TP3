using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformation : MonoBehaviour
{
    [Range(1.5f, 5f)]
    public float radius = 2f;

    [Range(0.5f, 5f)]
    public float deformationStrength = 2f;

    private Mesh mesh;

    private Vector3[] verticies, modifiedVerticies;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<MeshFilter>().mesh;
        //Ajout des mesh dans les 2 tab
        verticies = mesh.vertices;
        modifiedVerticies = mesh.vertices;
    }


    void RecalculateMesh()
    {
        mesh.vertices = modifiedVerticies;
        GetComponentInChildren<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateNormals();
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            for (int v = 0; v < modifiedVerticies.Length; v++)
            {
                Vector3 distance = modifiedVerticies[v] - hit.point;

                float smoothingFactor = 2f;
                float force = deformationStrength / (1f + hit.point.sqrMagnitude);

                if (distance.sqrMagnitude < radius)
                {
                    //Click button gauche
                    if (Input.GetMouseButton(0))
                    {
                        Debug.LogError("Je grossis");

                        modifiedVerticies[v] = modifiedVerticies[v] + (Vector3.up * force) / smoothingFactor;
                    }
                    else if (Input.GetMouseButton(1))
                    {
                        Debug.LogError("Je rétrécis");

                        modifiedVerticies[v] = modifiedVerticies[v] + (Vector3.down * force) / smoothingFactor;

                    }
                    Debug.LogError("JSP ce que ça fait");
                }
            }
        }

        RecalculateMesh();

    }
}