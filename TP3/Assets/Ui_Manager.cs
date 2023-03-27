using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Manager : MonoBehaviour
{
    public Text Resolution;
    public Text Dimension;
    public Text Triangles;
    public Text Vertices;
    public Text ZoomSpeed;

    public void SetPlaneValues(int dimension, int resolution, int triangles, int vertices)
    {
        Dimension.text = dimension.ToString();
        Resolution.text = resolution.ToString();
        Triangles.text = triangles.ToString();
        Vertices.text = vertices.ToString();
    }

    public void SetZoomSpeedValues(int zoomSpeed)
    {
        ZoomSpeed.text = zoomSpeed.ToString();
    }
}