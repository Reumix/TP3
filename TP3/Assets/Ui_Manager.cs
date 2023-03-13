using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public CreatePlane createplane;

    public Text Resolution;
    public Text Dimension;
    
    
    public Button btn;
    public float rotationSpeed = 100f; // vitesse de rotation

    void Start()
    {
        btn.onClick.AddListener(Rotate);
        UpdateText();
    }

    private void UpdateText()
    {
        //Resolution.text = createplane.resolution;
        //Dimension.text = createplane.dimension;
        Dimension.text += (createplane.dimension).ToString();
        Resolution.text += (createplane.resolution).ToString();
    }

    private void Rotate()
    {
        //createplane.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
