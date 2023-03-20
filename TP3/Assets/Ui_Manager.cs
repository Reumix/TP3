using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Ui_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public CreatePlane createplane;

    public Text Resolution;
    public Text Dimension;
    public Text Triangles;
    public Text Vertices;

    void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        Dimension.text = (createplane.dimension).ToString();
        Resolution.text = (createplane.resolution).ToString();
        GetValues();
    }

    async private void GetValues()
    {
        await Task.Delay(500);
        Triangles.text = (createplane.GetNbTriangles()).ToString();
        Vertices.text = (createplane.GetNbVertices()).ToString();
    }
}